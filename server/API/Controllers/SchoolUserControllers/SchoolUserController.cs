using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    public class SchoolUserController : Controller
    {
        private readonly ISchoolUserService _schoolUserService;

        public SchoolUserController(ISchoolUserService schoolUserService)
        {
            _schoolUserService = schoolUserService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> Get()
        {
            try
            {
                var schoolUsers = _schoolUserService.GetAllSchoolUsers();
                return Ok(schoolUsers);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Get(string id)
        {
            return _schoolUserService.GetSchoolUserBaseModel(id);
        }
    }
}
