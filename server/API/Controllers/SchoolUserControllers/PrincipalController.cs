using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("principal")]
    [Produces("application/json")]
    public class PrincipalController : BaseController
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IPrincipalService _principalService;

        public PrincipalController(
            ILogger<BaseController> logger,
            IPrincipalService principalService) : base(logger)
        {
            _logger = logger;
            _principalService = principalService;
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public async Task Create([FromBody] PrincipalModel principalModel)
        {
            await _principalService.AddPrincipal(principalModel);
        }
    }
}
