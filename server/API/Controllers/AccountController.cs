using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;

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
        
//      This endpoint won't be called but is kept for testing purposes (e.g. requests with Postman)   
        [HttpPost("register")]
        public async Task<User> Register([FromBody] FullRegisterInputModel inputModel)
        {
            return await this.AccountService.Register(inputModel);
        }
        
        [HttpPost("login")]
        public async Task<LoginViewModel> Login ([FromBody] LoginInputModel model)
        {
            return await this.AccountService.LogIn(model);
        }
        
        [HttpPost("logout")]
        public async Task Logout ()
        {
            await this.AccountService.Logout();
        }
    }
}