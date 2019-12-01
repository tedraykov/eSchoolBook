using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class UserService : BaseService, IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        
        public UserService(
            SignInManager<User> signInManager,
            JwtSettings jwtSettings,
            IRepositories repositories, 
            UserManager<User> userManager, 
            IMapper mapper) : base(repositories, userManager, mapper)
        {
            this._signInManager = signInManager;
            this._jwtSettings = jwtSettings;
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
//            var role = this.Repositories

            await this.UserManager.CreateAsync(user);
//            await this.UserManager.AddToRoleAsync(user, Enum.GetName())

            return this.Mapper.Map<User,RegisterViewModel>(user);
        }

        public async Task Logout()
        {
            await this._signInManager.SignOutAsync();
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
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
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