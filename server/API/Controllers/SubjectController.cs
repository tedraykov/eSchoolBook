using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces;

namespace SchoolBook.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("subject")]
    public class SubjectController : BaseController
    {
        private ISubjectService SubjectService { get; set; }
        
        public SubjectController(
            ISubjectService subjectService,
            ILogger<ClassController> logger
        ) : base(logger)
        {
            this.SubjectService = subjectService;
        }

        [HttpGet]
        public List<SubjectViewModel> GetAll()
        {
            return SubjectService.GetAll();
        }
        
        [HttpGet("grade/{year}")]
        public List<SubjectViewModel> GetAllByGradeYear([FromRoute] int year)
        {
            return SubjectService.GetAllByGradeYear(year);
        }
        
        [HttpGet("teacher/{teacherId}")]
        public List<SubjectOnlyViewModel> GetAllByTeacherId([FromRoute] string teacherId)
        {
            return SubjectService.GetAllByTeacherId(teacherId);
        }
        
        [HttpGet("students/{subjectId}")]
        public List<StudentViewModel> StudentsAttending(string subjectId)
        {
            return SubjectService.GetStudentsAttending(subjectId);
        }
        
        [HttpGet("id/{id}")]
        public SubjectViewModel GetById([FromRoute] string id)
        {
            return SubjectService.GetOneById(id);
        }
        
        [HttpPost]
        public void AddSubject([FromBody] SubjectInputModel inputModel)
        {
            SubjectService.AddSubject(inputModel);
        }
        
        [HttpPut("{id}")]
        public SubjectViewModel EditSubject([FromRoute] string id, [FromBody] SubjectInputModel inputModel)
        {
            return  SubjectService.EditSubject(id, inputModel);
        }
        
        [HttpPost("teacher/{subjectId}")]
        public void AddTeacherToSubject([FromRoute] string subjectId, [FromBody] string teacherId)
        {
            SubjectService.AddTeacherToSubject(subjectId, teacherId);
        }
        
        [HttpDelete("teacher/{subjectId}")]
        public void RemoveTeacherFromSubject([FromRoute] string subjectId, [FromBody] string teacherId)
        {
            SubjectService.RemoveTeacherFromSubject(subjectId, teacherId);
        }
        
        [HttpDelete("{id}")]
        public void DeleteSubject([FromRoute] string id)
        {
            SubjectService.DeleteSubject(id);
        }
    }
}