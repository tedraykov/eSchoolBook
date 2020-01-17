using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SchoolBook.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        protected  ILogger<BaseController> Logger { get; set; }

        public BaseController(ILogger<BaseController> logger)
        {
            this.Logger = logger;
        }

        public List<Claim> GetJwtClaims(string jwt)
        {
            var claims = new List<Claim>();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var token = handler.ReadToken(jwt) as JwtSecurityToken;

            return ((List<Claim>) token?.Claims);
        }
    }
}