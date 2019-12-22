using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        [HttpPut("{id}/add-teacher")]
        public void AddClassTeacher([FromRoute] string id, [FromBody] TeacherInputModel inputModel)
        {
            this.ClassService.AddClassTeacher(id, inputModel);
        }
        
        [HttpPut("{id}")]
        public ClassViewModel EditClass([FromRoute] string id, [FromBody] ClassInputModel inputModel)
        {
            return this.ClassService.EditClass(id, inputModel);
        }
    }
}