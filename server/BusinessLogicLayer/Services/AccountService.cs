using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;
using SchoolBook.Helpers;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class AccountService : BaseService, IAccountService
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public AccountService(
            SignInManager<User> signInManager,
            IRepositories repositories, 
            UserManager<User> userManager,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, logger, mapper)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<LoginViewModel> LogIn(LoginInputModel loginInputModel)
        {
            var user = this._userManager.Users
                .SingleOrDefault(u => u.Email == loginInputModel.Email);

            if (user is null)
            {
                throw new ArgumentException("Invalid user credentials.");
            }

            var result = this._signInManager.CheckPasswordSignInAsync(user, loginInputModel.Password, false);

            if (!result.Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Invalid user credentials.");
            }

            var loginViewModel = new LoginViewModel
            {
                AccessToken = await this.GenerateJwt(user)
            };

            return loginViewModel;
        }

        public async Task<User> Register(FullRegisterInputModel inputModel)
        {
            var email = GenerateEmail(inputModel.FirstName, inputModel.LastName);
            
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                UserName = email,
                RoleName = inputModel.RoleName
            };

            var roles = Enum.GetValues(typeof(RoleTypes));
            var role = roles.GetValue(0);
            
            foreach (var r in roles)
            {
                if (role.ToString() == inputModel.RoleName) break;
                if (r.ToString() == inputModel.RoleName)
                {
                    role = r;
                }
            }
                
            await _userManager.CreateAsync(user, inputModel.Pin);
            await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleTypes), role));

            return user;
        }

        public async Task Logout()
        {
            await this._signInManager.SignOutAsync();
        }
        
        public async Task SeedAdmin(RegisterInputModel model)
        {
            if (this.Repositories.Users.Query().Count(au => au.Email == model.Email) == 0)
            {
                try
                {
                    var user = this.Mapper.Map<RegisterInputModel, User>(model);
                    user.UserName = user.Email;
                    user.RoleName = Enum.GetName(typeof(RoleTypes), RoleTypes.SuperAdmin);
                    await this._userManager.CreateAsync(user, model.Password);
                    await this._userManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleTypes), RoleTypes.SuperAdmin));
                }
                catch (Exception e)
                {
                    this.Logger.LogWarning(e, "Error: Seed Admin User Failed: " + e.Message);
                }
            }
        }

        private async Task<string> GenerateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("ESCHOOLBOOK_ENV_JWT"));
            var isUserAdmin = await _userManager.IsInRoleAsync(user, RoleTypes.SuperAdmin.ToString());
            var userSchoolId = Repositories.SchoolUsers.Query()
                                 .AsNoTracking()
                                 .Include(su => su.School)
                                 .FirstOrDefault(su => su.User.Id == user.Id)?.School.Id ?? "no id";

            var names = "Admin";
            
            if (!isUserAdmin)
            {
                var schoolUser = Repositories.SchoolUsers.Query()
                    .AsNoTracking()
                    .Include(su => su.School)
                    .FirstOrDefault(su => su.User.Id == user.Id);
                names = schoolUser.FirstName + " " + schoolUser.SecondName + " "  + schoolUser.LastName;
            }
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim("schoolId", userSchoolId, ClaimValueTypes.String),
                    new Claim("userNames", names, ClaimValueTypes.String),
                    new Claim("isAdmin", isUserAdmin.ToString(), ClaimValueTypes.Boolean),
                    new Claim(ClaimTypes.Role, user.RoleName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private string GenerateEmail(string firstName, string lastName)
        {
            var emailPrefix = firstName.Substring(0,1).ToLower() + lastName.ToLower();
            var counter = Repositories.Users.Query().AsNoTracking().Count(u => u.Email.Contains(emailPrefix));

            if (counter >= 1)
            {
                emailPrefix = emailPrefix + counter;
            }

            return emailPrefix + "@eschoolbook.bg";

        }

        public async Task<User> RegisterSchoolUser(SchoolUser schoolUser)
        {
            var accountRegister = new FullRegisterInputModel
            {
                Pin = schoolUser.Pin,
                FirstName = schoolUser.FirstName,
                LastName = schoolUser.LastName,
                RoleName = schoolUser.Role.ToString()
            };
            return await Register(accountRegister);
        }
    }
}
