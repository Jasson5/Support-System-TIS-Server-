using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class FinalGradeRepository : IFinalGradeRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public FinalGradeRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Add(ICollection<FinalGrade> FinalGrades)
        {
            _dataAccess.AddRange(FinalGrades);
            _dataAccess.SaveChanges();
        }

        public void Delete(string companyName)
        {
            _dataAccess.Set<FinalGrade>().FromSqlRaw($"dbo.DeleteUserCompany '{companyName}'");
            _dataAccess.SaveChanges();
        }

        public ICollection<FinalGrade> ListFinalGrade(string companyName)
        {
            var finalGrade = _dataAccess.Set<FinalGrade>().FromSqlRaw($"dbo.GetFInalGradeByCompany '{companyName}'").AsEnumerable();

            return finalGrade.ToList();
        }

        public void Update(FinalGrade finalGrade)
        {
            var FinalGradeToEdit = _dataAccess.Set<FinalGrade>().Find(finalGrade.Id);

            FinalGradeToEdit.Grade = finalGrade.Grade;
            _dataAccess.SaveChanges();
        }
    }
}
