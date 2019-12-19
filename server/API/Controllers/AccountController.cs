using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;

namespace SchoolBook.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("account")]
    public class AccountController : BaseController
    {
        private  IAccountService AccountService { get; set; }
        
        public AccountController(
            IAccountService authService,
            ILogger<AccountController> logger
            ): base(logger)
        {
            this.AccountService = authService;
        }
        
        [HttpPost("register")]
        public async Task<RegisterViewModel> Register([FromBody] RegisterInputModel model)
        {
            return await this.AccountService.Register(model);
        }
        
        [HttpPost("login")]
        public async Task<LoginViewModel> Login ([FromBody] LoginInputModel model)
        {
            return await this.AccountService.LogIn(model);
        }
    }
}