using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.BusinessLogicLayer.Services;

namespace SchoolBook.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("school")]
    public class SchoolController : BaseController
    {
        private ISchoolService SchoolService { get; set; }
        
        public SchoolController(
            ISchoolService schoolService,
            ILogger<BaseController> logger
        ) : base(logger)
        {
            this.SchoolService = schoolService;
        }
        
        [HttpGet]
        public ICollection<SchoolViewModel> GetAll()
        {
            return SchoolService.GetAll();
        }
        
        [HttpGet("{id}")]
        public SchoolViewModel GetById([FromRoute] string id)
        {
            return SchoolService.GetOneById(id);
        }
        
        [HttpPost()]
        public void AddSchool([FromBody] SchoolInputModel inputModel)
        {
            SchoolService.AddSchool(inputModel);
        }
        
        [HttpPut("{id}")]
        public void EditSchool([FromRoute] string id, [FromBody] SchoolInputModel inputModel)
        {
            SchoolService.EditSchool(id, inputModel);
        }
        
        [HttpDelete("{id}")]
        public void DeleteSchool([FromRoute] string id)
        {
            SchoolService.DeleteSchool(id);
        }
    }
}