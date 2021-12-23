using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IFinalGradeRepository
    {
        void Add(ICollection<FinalGrade> FinalGrades);
        ICollection<FinalGrade> ListFinalGrade(string companyName);
        void Update(FinalGrade finalGrade);
        void Delete(string companyName);
    }
}
