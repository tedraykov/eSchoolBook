using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models;
using SchoolBook.BusinessLogicLayer.Interfaces;

namespace SchoolBook.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("statistics")]
    public class StatisticalController: BaseController
    {
        private IStatisticalService StatisticalService;
        
        public StatisticalController(
            IStatisticalService statisticalService,
            ILogger<BaseController> logger
            ) : base(logger)
        {
            StatisticalService = statisticalService;
        }

        [HttpGet("school-score/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public double GetSchoolScore([FromRoute]string schoolId)
        {
            return StatisticalService.SchoolAverageScore(schoolId);
        }
        
        [HttpGet("subjects-score/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public ICollection<StringDoubleModel> AverageSubjectScores([FromRoute]string schoolId)
        {
            return StatisticalService.AverageSubjectScores(schoolId);
        }
        
        [HttpGet("teachers-score/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public ICollection<StringDoubleModel> AverageTeacherScores([FromRoute]string schoolId)
        {
            return StatisticalService.AverageTeacherScores(schoolId);
        }
        
        [HttpGet("school-absences/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public ICollection<StringDoubleModel> SchoolAbsences([FromRoute]string schoolId)
        {
            return StatisticalService.SchoolAbsences(schoolId);
        }
        
        /*All schools statistics (Admin panel)*/
        [HttpGet("scores")]
        [Authorize(Roles = "SuperAdmin")]
        public double GetSchoolScore()
        {
            return StatisticalService.SchoolAverageScore();
        }
        
        [HttpGet("teachers-scores")]
        [Authorize(Roles = "SuperAdmin")]
        public IDictionary<string, double> AverageTeacherScores()
        {
            return StatisticalService.AverageTeacherScores();
        }
        
        [HttpGet("subjects-scores")]
        [Authorize(Roles = "SuperAdmin")]
        public IDictionary<string, double> AverageSubjectScores()
        {
            return StatisticalService.AverageSubjectScores();
        }
    
        [HttpGet("best/{n}")]
        [Authorize(Roles = "SuperAdmin")]
        public ICollection GetBestSchools(int n)
        {
            return StatisticalService.BestNSchools(n);
        }
        
        [HttpGet("absences")]
        [Authorize(Roles = "SuperAdmin")]
        public IDictionary<string, ICollection<StringDoubleModel>> SchoolAbsences()
        {
            return StatisticalService.SchoolAbsences();
        }
    }
}