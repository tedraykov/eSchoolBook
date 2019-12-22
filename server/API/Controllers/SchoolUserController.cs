using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;

namespace SchoolBook.API.Controllers
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
        public ActionResult<SchoolUserModel> Get(string id)
        {
            try
            {
                var schoolUser = _schoolUserService.GetSchoolUserBaseModel(id);
                return schoolUser;
            }
            catch (Exception e)
            {
                return NotFound("User not found");
            }
        }

        [HttpPost]
        public ActionResult<string> Create([FromBody]AddSchoolUserInputModel userModel)
        {
            try
            {
                var userId = _schoolUserService.AddSchoolUser(userModel);
                return Created($"/api/users/{userId}", userId);
            }
            catch (Exception e)
            {
                return BadRequest("Could not create user");
            }
        }

        [HttpPut("{Id}")]
        public ActionResult Update([FromBody] SchoolUserModel userModel)
        {
            try
            {
                _schoolUserService.UpdateBaseSchoolUser(userModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Could not update user");
            }
        }
    }
}
