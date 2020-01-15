using System.Collections;
using System.Collections.Generic;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IStatisticalService
    {
        /*Statistics for specific school*/
        double SchoolAverageScore(string schoolId);

        IDictionary<string, double> AverageSubjectScores(string schoolId);

        IDictionary<string, double> AverageTeacherScores(string schoolId);

        IDictionary<string, int>  SchoolAbsences(string schoolId);
        
        /*Statistics for all schools in DB*/
        double SchoolAverageScore();
        
        ICollection  BestNSchools(int n);

        IDictionary<string, double> AverageSubjectScores();

        IDictionary<string, double> AverageTeacherScores();

        IDictionary<string, IDictionary<string, int>>  SchoolAbsences();
        
        /*Statistics for a single user*/

        double StudentAverageScore(string studentId);
        
       IDictionary<string, int> StudentAbsences(string studentId);
       
       double TeacherAverageScore(string teacherId);
    }
}