using System.Collections;
using System.Collections.Generic;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IStatisticalService
    {
        /*For Specific School*/
        int SchoolAverageScore(string schoolId);

        IDictionary<string, double> AverageSubjectScores(string schoolId);

        IDictionary<string, double> AverageTeacherScores(string schoolId);

        IDictionary<string, int>  SchoolAbsences(string schoolId);
        
        /*For All Schools in DB*/
        int SchoolAverageScore();
        
        IDictionary<string, double>  BestNSchools(int n);

        IDictionary<string, double> AverageSubjectScores();

        IDictionary<string, double> AverageTeacherScores();

        IDictionary<string, int>  SchoolAbsences();
    }
}