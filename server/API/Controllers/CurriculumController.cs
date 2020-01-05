using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces;

namespace SchoolBook.API.Controllers

{
    [Authorize]
    [ApiController]
    [Route("curriculum")]
    public class CurriculumController : BaseController
    {
        private ICurriculumService CurriculumService { get; set; }
        
        public CurriculumController(
            ICurriculumService curriculumService,
            ILogger<BaseController> logger
            ) : base(logger)
        {
            CurriculumService = curriculumService;
        }
        
        [HttpGet("teacher-subjects/{teacherId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        public List<T_ClassToSubjectViewModel> GetTeacherActiveSubjects([FromRoute] string teacherId)
        {
            return this.CurriculumService.GetTeacherActiveSubjects(teacherId);
        }
        
        
        [HttpGet("class-students/{classCurriculumId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        public List<StudentViewModel> GetStudentsInClassAttendingSubject([FromRoute] string classCurriculumId)
        {
            return this.CurriculumService.GetStudentsInClassAttendingSubject(classCurriculumId);
        }
        
        [HttpGet("student/{studentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher, Student, Parent")]
        public List<S_ClassToSubjectViewModel> GetStudentWeeklyCurriculum([FromRoute] string studentId)
        {
            return this.CurriculumService.GetStudentWeeklyCurriculum(studentId);
        }
    }
}