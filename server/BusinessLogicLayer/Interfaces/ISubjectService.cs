using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ISubjectService
    {
        List<SubjectViewModel> GetAll();
        
        List<SubjectViewModel> GetAllByGradeYear(int grade);
        
        SubjectViewModel GetOneById (string id);

        SubjectViewModel GetOneBySignature(string signature);

        void AddSubject(SubjectInputModel inputModel);

        SubjectViewModel EditSubject(string id, SubjectInputModel inputModel);

        void AddTeacherToSubject(string subjectId, string teacherId);
        
        void RemoveTeacherFromSubject(string subjectId, string teacherId);

        void DeleteSubject(string id);
    }
}