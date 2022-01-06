using DataAccess.Model;
using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IFinalGradeRepository
    {
        void Add(ICollection<FinalGrade> FinalGrades);
        ICollection<FinalGrade> ListFinalGrade(string companyName);
        ICollection<FinalGradeBySemester> ListFinalGradeBySemester(string semesterCode);
        void Update(FinalGrade finalGrade);
        void Delete(string CompanyName);
    }
}
