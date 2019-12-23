using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("api/students")]
    [ApiController]
    [Produces("application/json")]
    public class StudentController : BaseController
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(
            ILogger<BaseController> logger,
            IStudentService studentService) : base(logger)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentInputModel>> Get()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpPost]
        public ActionResult Create([FromBody] StudentInputModel studentModel)
        {
            try
            {
                var studentId = _studentService.AddStudent(studentModel);
                return Created($"/api/users/{studentId}", studentId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<StudentInputModel> GetById(string id)
        {
            return _studentService.GetStudent(id);
        }
    }
}
