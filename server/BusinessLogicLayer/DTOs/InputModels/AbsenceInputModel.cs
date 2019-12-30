namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class AbsenceInputModel
    {
        public string StudentId { get; set; }

        public bool IsFullAbsence { get; set; }

        public string SubjectId { get; set; }
    }
}