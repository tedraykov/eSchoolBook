using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;

namespace SchoolBook.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("class")]
    public class ClassController : BaseController
    {
        private IClassService ClassService { get; set; }
        
        public ClassController(
            IClassService classService,
            ILogger<ClassController> logger
            ) : base(logger)
        {
            this.ClassService = classService;
        }

        /*Get all classes in DB.*/
        [HttpGet]
        public List<ClassViewModel> GetAll()
        {
            return this.ClassService.GetAll();
        }

        [HttpGet("school/{schoolId}")]
        public List<ClassViewModel> GetBySchool([FromRoute] string schoolId)
        {
            return this.ClassService.GetAllBySchool(schoolId);
        }
        
        /*Get all classes by class grade. E.g. all first graders.*/
        [HttpGet("grade/{grade}")]
        public List<ClassViewModel> GetAllByGrade([FromRoute] int grade)
        {
            return this.ClassService.GetAllByGrade(grade);
        }
        
        /*Get all classes in school that don't have a class teacher assigned to them.*/
        [HttpGet("unassigned/{schoolId}")]
        public List<MinimalClassViewModel> GetClassesWithoutClassTeacher([FromRoute] string schoolId)
        {
            return this.ClassService.GetClassesWithoutClassTeacher(schoolId);
        }
        
        /*Get one class by class id.*/
        [HttpGet("{id}")]
        public ClassViewModel GetOne([FromRoute] string id)
        {
            return this.ClassService.GetOne(id);
        }
        
        /*Create new class row in DB table.*/
        [HttpPost()]
        public void AddClass([FromBody] ClassInputModel inputModel)
        {
            this.ClassService.AddClass(inputModel);
        }
        
        /* Assign class teacher to existing class. Teacher cannot already be in any of the table rows. */
        [HttpPut("teacher/{classId}")]
        public void AddClassTeacher([FromRoute] string classId, [FromBody]string teacherId)
        {
            this.ClassService.AddClassTeacher(classId, teacherId);
        }
        
        /* Add subject to class Subjects collection. Also specializes what day
         and time subject will be attended by this class. And which teacher will be assigned to teach it. */
        [HttpPost("subject/{classId}")]
        public void AddSubjectToClass([FromRoute] string classId, [FromBody]ClassToSubjectInputModel inputModel)
        {
            this.ClassService.AddSubject(classId, inputModel);
        }
        
        /*Edit subject already in the subjects collection of a class.
         You can edit the time and day, the teacher as well.*/
        [HttpPut("subject/{classId}")]
        public void EditSubjectInClass([FromRoute] string classId, [FromBody]ClassToSubjectInputModel inputModel)
        {
            this.ClassService.EditSubject(classId, inputModel);
            }
        
        /*Remove a subject from subjects collection of a class.*/
        [HttpDelete("subject/{classId}")]
        public void RemoveSubjectFromClass([FromRoute] string classId, [FromBody]string subjectId)
        {
            this.ClassService.RemoveSubject(classId, subjectId);
        }

        /*Edit class data. Doesn't change class teacher.*/
        [HttpPut("{id}")]
        public ClassViewModel EditClass([FromRoute] string id, [FromBody] ClassInputModel inputModel)
        {
            return this.ClassService.EditClass(id, inputModel);
        }
    }
}