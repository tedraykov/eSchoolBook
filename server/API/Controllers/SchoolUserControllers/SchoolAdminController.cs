using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("admin")]
    [Produces("application/json")]
    public class SchoolAdminController : BaseController
    {
        private readonly ISchoolAdminService _schoolAdminService;

        public SchoolAdminController(
            ILogger<BaseController> logger,
            ISchoolAdminService schoolAdminService) : base(logger)
        {
            _schoolAdminService = schoolAdminService;
        }
        
        [HttpPost]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public async Task Create([FromBody] SchoolAdminModel schoolAdminModel)
        {
            await _schoolAdminService.AddSchoolAdmin(schoolAdminModel);
        }
    }
}