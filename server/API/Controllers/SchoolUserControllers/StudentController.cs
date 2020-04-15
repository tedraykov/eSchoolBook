using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers.Edit;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("students")]
    [ApiController]
    [Produces("application/json")]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(
            ILogger<BaseController> logger,
            IStudentService studentService) : base(logger)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IEnumerable<StudentModel> GetAll()
        {
            return _studentService.GetAllStudents();
        }
        
        [HttpGet("school/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public IEnumerable<StudentTableViewModel> GetAllBySchool([FromRoute] string schoolId)
        {
            return _studentService.GetAllStudentsFromSchool(schoolId);
        }
        
        [HttpGet("class/{classId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        public IEnumerable<StudentModel> GetAllByClass([FromRoute] string classId)
        {
            return _studentService.GetAllStudentsFromClass(classId);
        }

        [HttpGet("{id}")]
        public StudentModel GetById(string id)
        {
            return _studentService.GetStudent(id);
        }
        
        [HttpGet("dialog/{studentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        public StudentDialogViewModel GetForDialog(string studentId)
        {
            return _studentService.GetStudentDialogData(studentId);
            }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public async Task Create([FromBody] StudentModel studentModel)
        {
            await _studentService.AddStudent(studentModel);
        }
        
        [HttpPost("grade/{studentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        public void GradeStudent([FromRoute] string studentId, [FromBody] GradeInputModel gradeModel)
        {
            _studentService.GradeStudent(studentId, gradeModel);
        }
        
        [HttpPut("grade/{gradeId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        public void EditStudentGrade([FromRoute] string gradeId, [FromBody] string newGradeId)
        {
            _studentService.EditGrade(gradeId, newGradeId);
        }
        
        [HttpDelete("grade/{gradeId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public void DeleteStudentGrade([FromRoute] string gradeId)
        {
            _studentService.RemoveGrade(gradeId);
        }

        [HttpPost("absence/{studentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        public void AddAbsence([FromRoute] string studentId, [FromBody] AbsenceInputModel absenceModel)
        {
            _studentService.AddAbsenceToStudent(studentId, absenceModel);
        }
        
        [HttpPut("absence/{studentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal, Teacher")]
        //TODO authorize by JWT claims
        public void ExcuseAbsence([FromRoute] string studentId, [FromBody] string absenceId)
        {
            _studentService.ExcuseStudentAbsence(studentId, absenceId);
        }
        
        [HttpPut("{studentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public void Update([FromRoute] string studentId, [FromBody] StudentEditInputModel editModel)
        {
            _studentService.UpdateStudent(studentId, editModel);
        }
        
        [HttpDelete("{studentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public void Delete([FromRoute] string studentId)
        {
            _studentService.RemoveStudent(studentId);
        }
    }
}
