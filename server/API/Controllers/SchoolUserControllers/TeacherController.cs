using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Teacher;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("teacher")]
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
        
        [HttpGet("dropdown/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public IEnumerable<MinimalSchoolUserModel> GetAllTeachersFromSchoolDropdown([FromRoute] string schoolId)
        {
            return this.TeacherService.GetAllTeachersFromSchoolDropdown(schoolId);
        }
        
        [HttpGet("subject/{subjectId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public IEnumerable<MinimalSchoolUserModel> GetTeachersListFromSubject([FromRoute] string subjectId)
        {
            return this.TeacherService.GetTeachersListFromSubject(subjectId);
        }
        
        [HttpGet("unassigned/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public IEnumerable<MinimalSchoolUserModel> GetAllUnassignedToClass([FromRoute] string schoolId)
        {
            return this.TeacherService.GetAllUnassignedToClass(schoolId);
        }
        
        [HttpGet("dialog/{teacherId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public TeacherDialogViewModel GetTeacherDialogData([FromRoute] string teacherId)
        {
            return this.TeacherService.GetTeacherDialogData(teacherId);
        }
        
        [HttpPost]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public async Task AddTeacher([FromBody] TeacherModel teacherModel)
        {
            await TeacherService.AddTeacher(teacherModel);
        }
    }
}