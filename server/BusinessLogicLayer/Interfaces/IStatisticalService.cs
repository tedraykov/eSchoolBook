using System.Collections;
using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.Models;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IStatisticalService
    {
        /*Statistics for specific school*/
        double SchoolAverageScore(string schoolId);

        ICollection<StringDoubleModel> AverageSubjectScores(string schoolId);

        ICollection<StringDoubleModel> AverageTeacherScores(string schoolId);

        ICollection<StringDoubleModel> SchoolAbsences(string schoolId);
        
        /*Statistics for all schools in DB*/
        double SchoolAverageScore();
        
        ICollection  BestNSchools(int n);

        IDictionary<string, double> AverageSubjectScores();

        IDictionary<string, double> AverageTeacherScores();

        IDictionary<string, ICollection<StringDoubleModel>>  SchoolAbsences();
        
        /*Statistics for a single user*/

        double StudentAverageScore(string studentId);
        
       IDictionary<string, int> StudentAbsences(string studentId);
       
       double TeacherAverageScore(string teacherId);
    }
}