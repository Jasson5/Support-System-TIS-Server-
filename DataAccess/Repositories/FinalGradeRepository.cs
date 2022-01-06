using DataAccess.Interfaces;
using DataAccess.Model;
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

        public void Add(ICollection<FinalGrade> FinalGrades) //Aniadir nota final
        {
            _dataAccess.AddRange(FinalGrades);
            _dataAccess.SaveChanges();
        }

        public void Delete(string CompanyName) //Eiminar nota final
        {
            var gradedelete = _dataAccess.Set<FinalGrade>().FromSqlRaw($"dbo.DeleteFinalGradeByCompany '{CompanyName}'").AsEnumerable().ToList();
            _dataAccess.Set<FinalGrade>().RemoveRange(gradedelete);
            _dataAccess.SaveChanges();

        }

        public ICollection<FinalGrade> ListFinalGrade(string companyName) //Listar notas finales de una compania
        {
            var finalGrade = _dataAccess.Set<FinalGrade>().FromSqlRaw($"dbo.GetFInalGradeByCompany '{companyName}'").AsEnumerable();

            return finalGrade.ToList();
        }

        public ICollection<FinalGradeBySemester> ListFinalGradeBySemester(string semesterCode) //Listar notas finales por semestre
        {
            var finalGrades = _dataAccess.Set<FinalGradeBySemester>().FromSqlRaw($"dbo.GetFInalGradesBySemester '{semesterCode}'");

            return finalGrades.ToList();
        }

        public void Update(FinalGrade finalGrade) //Actualizar notas finales
        {
            var FinalGradeToEdit = _dataAccess.Set<FinalGrade>().Find(finalGrade.Id);

            FinalGradeToEdit.Grade = finalGrade.Grade;
            _dataAccess.SaveChanges();
        }
    }
}
