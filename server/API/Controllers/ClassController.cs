using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers;
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

        [HttpGet]
        public List<ClassViewModel> GetAll()
        {
            return this.ClassService.GetAll();
        }
        
        [HttpGet("grade/{grade}")]
        public List<ClassViewModel> GetAllByGrade([FromRoute] int grade)
        {
            return this.ClassService.GetAllByGrade(grade);
        }
        
        [HttpGet("{id}")]
        public ClassViewModel GetOne([FromRoute] string id)
        {
            return this.ClassService.GetOne(id);
        }
        
        [HttpPost()]
        public void AddClass([FromBody] ClassInputModel inputModel)
        {
            this.ClassService.AddClass(inputModel);
        }
        
        [HttpPut("teacher/{classId}")]
        public void AddClassTeacher([FromRoute] string classId, [FromBody]string teacherId)
        {
            this.ClassService.AddClassTeacher(classId, teacherId);
        }
        
        [HttpPost("add-subject/{classId}")]
        public void AddSubjectToClass([FromRoute] string classId, [FromBody]ClassToSubjectInputModel inputModel)
        {
            this.ClassService.AddSubject(classId, inputModel);
        }
        
        [HttpPut("edit-subject/{classId}")]
        public void EditSubjectInClass([FromRoute] string classId, [FromBody]ClassToSubjectInputModel inputModel)
        {
            this.ClassService.EditSubject(classId, inputModel);
            }
        
        [HttpDelete("remove-subject/{classId}")]
        public void RemoveSubjectFromClass([FromRoute] string classId, [FromBody]string subjectId)
        {
            this.ClassService.RemoveSubject(classId, subjectId);
        }

        
        [HttpPut("{id}")]
        public ClassViewModel EditClass([FromRoute] string id, [FromBody] ClassInputModel inputModel)
        {
            return this.ClassService.EditClass(id, inputModel);
        }
    }
}