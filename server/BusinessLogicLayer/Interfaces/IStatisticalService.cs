using System.Collections;
using System.Collections.Generic;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IStatisticalService
    {
        int SchoolAverageScore(string schoolId);

        IDictionary<string, double> AverageSubjectScores(string schoolId);

        IDictionary<string, double> AverageTeacherScores(string schoolId);

        IDictionary<string, int>  SchoolAbsences(string schoolId);
    }
}