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
            if (this.UserManager.Users.SingleOrDefault(u => u.Email == registerInputModel.Email) != null)
            {
                //TODO Throw an exception after implementing Exception Handling Middleware
                Logger.LogError("User with this email already exists.");
                return null;
            }
            
            var roles = Enum.GetValues(typeof(RoleTypes));
            var role = roles.GetValue(0);
            
            foreach (var r in roles)
            {
                if (r.ToString() == user.RoleName)
                {
                    role = r;
                }
            }
                
            await this.UserManager.CreateAsync(user);
            await this.UserManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleTypes), role));

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
                    user.RoleName = Enum.GetName(typeof(RoleTypes), RoleTypes.SuperAdmin);
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
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var isUserAdmin = await UserManager.IsInRoleAsync(user, RoleTypes.SuperAdmin.ToString());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("isAdmin", isUserAdmin.ToString(), ClaimValueTypes.Boolean),
                    new Claim(ClaimTypes.Role, user.RoleName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}