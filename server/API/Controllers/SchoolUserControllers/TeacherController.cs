using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("teacher")]
    [Produces("application/json")]
    public class TeacherController : BaseController
    {
        private readonly ILogger<BaseController> _logger;
        private readonly ITeacherService _teacherService;

        public TeacherController(
            ILogger<BaseController> logger,
            ITeacherService teacherService) : base(logger)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public async Task AddTeacher([FromBody] TeacherModel teacherModel)
        {
            await _teacherService.AddTeacher(teacherModel);
        }
    }
}
