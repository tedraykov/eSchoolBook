using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Interfaces;
using SchoolBook.Helpers;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        
        public AccountService(
            SignInManager<User> signInManager,
            IOptions<JwtSettings> jwtSettings,
            IRepositories repositories, 
            UserManager<User> userManager,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, userManager, logger, mapper)
        {
            this._signInManager = signInManager;
            this._jwtSettings = jwtSettings.Value;
        }

        public async Task<LoginViewModel> LogIn(LoginInputModel loginInputModel)
        {
            var user = this.UserManager.Users
                .Include(u => u.Role)
                .SingleOrDefault(u => u.Email == loginInputModel.Email);

            if (user is null)
            {
                throw new ArgumentException("Invalid user credentials.");
            }

            var result = this._signInManager.CheckPasswordSignInAsync(user, loginInputModel.Password, false);

            if (!result.IsCompletedSuccessfully)
            {
                throw new UnauthorizedAccessException("Invalid user credentials.");
            }

            var loginViewModel = new LoginViewModel
            {
                AccessToken = await this.GenerateJwt(user)
            };

            return loginViewModel;
        }

        public async Task<RegisterViewModel> Register(RegisterInputModel registerInputModel)
        {
            var user = this.Mapper.Map<RegisterInputModel, User>(registerInputModel);
            user.UserName = user.Email;
                
            await this.UserManager.CreateAsync(user);
//            if (registerInputModel.RoleName == "Teacher")
//            {
//                await this.UserManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleTypes), RoleTypes.Teacher));
//            }

            return this.Mapper.Map<User,RegisterViewModel>(user);
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
                    user.UserName = "Admin";
                    await this.UserManager.CreateAsync(user, model.Password);
                    await this.UserManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleTypes), RoleTypes.SuperAdmin));
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
            var key = Encoding.UTF8.GetBytes(this._jwtSettings.Secret);
            var isUserAdmin = await this.UserManager.IsInRoleAsync(user, RoleTypes.SuperAdmin.ToString());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("isAdmin", isUserAdmin.ToString(), ClaimValueTypes.Boolean),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}