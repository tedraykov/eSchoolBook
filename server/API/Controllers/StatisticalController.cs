using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public double GetSchoolScore([FromRoute]string schoolId)
        {
            return StatisticalService.SchoolAverageScore(schoolId);
        }
        
        [HttpGet("subjects-score/{schoolId}")]
        public IDictionary<string, double> AverageSubjectScores([FromRoute]string schoolId)
        {
            return StatisticalService.AverageSubjectScores(schoolId);
        }
        
        [HttpGet("teachers-score/{schoolId}")]
        public IDictionary<string, double> AverageTeacherScores([FromRoute]string schoolId)
        {
            return StatisticalService.AverageTeacherScores(schoolId);
        }
        
        [HttpGet("school-absences/{schoolId}")]
        public IDictionary<string, int> SchoolAbsences([FromRoute]string schoolId)
        {
            return StatisticalService.SchoolAbsences(schoolId);
        }
        
        /*All schools statistics (Admin panel)*/
        [HttpGet("scores")]
        public int GetSchoolScore()
        {
            return StatisticalService.SchoolAverageScore();
        }
        
        [HttpGet("teachers-scores")]
        public IDictionary<string, double> AverageTeacherScores()
        {
            return StatisticalService.AverageTeacherScores();
        }
        
        [HttpGet("subjects-scores")]
        public IDictionary<string, double> AverageSubjectScores()
        {
            return StatisticalService.AverageSubjectScores();
        }
    
        [HttpGet("best/{n}")]
        public ICollection GetBestSchools(int n)
        {
            return StatisticalService.BestNSchools(n);
        }
        
        [HttpGet("absences")]
        public IDictionary<string, IDictionary<string, int>> SchoolAbsences()
        {
            return StatisticalService.SchoolAbsences();
        }
    }
}