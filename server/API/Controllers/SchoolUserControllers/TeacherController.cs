using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Teacher;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("teachers")]
    [ApiController]
    [Produces("application/json")]
    public class TeacherController : BaseController
    {
        private ITeacherService TeacherService;

        public TeacherController(
            ILogger<BaseController> logger,
            ITeacherService teacherService
            ) : base(logger)
        {
            TeacherService = teacherService;
        }

        [HttpGet("school/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public IEnumerable<TeacherTableViewModel> GetAllTeachersFromSchool([FromRoute] string schoolId)
        {
            return this.TeacherService.GetAllTeachersFromSchool(schoolId);
        }
    }
}