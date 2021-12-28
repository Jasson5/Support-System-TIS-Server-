using DataAccess.Model;
using Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IFinalGradeService
    {
        ICollection<FinalGrade> ListFinalGrades(string companyName);
        void Update(FinalGrade finalGrade);
        ICollection<FinalGradeBySemester> ListApprovedStudents(string semesterCode);
    }
}
