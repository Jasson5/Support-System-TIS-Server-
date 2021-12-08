using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public SemesterRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Semester Add(Semester semester)
        {
            _dataAccess.Set<Semester>().Add(semester);
            _dataAccess.SaveChanges();

            return semester;
        }

        public void Delete(Semester semester)
        {
            _dataAccess.Set<Semester>().Remove(semester);
            _dataAccess.SaveChanges();
        }

        public Semester FindById(int id)
        {
            var semester = _dataAccess.Set<Semester>().FromSqlRaw($"dbo.GetSemesterById '{id}'").AsEnumerable().SingleOrDefault();

            return semester;
        }

        public ICollection<Semester> ListSemesters(string search)
        {
            var semesters = _dataAccess.Set<Semester>().FromSqlRaw($"dbo.GetSemesters'{search}'").AsEnumerable();

            return semesters.ToList();
        }

        public void Update(Semester semester)
        {
            var SemesterToEdit = _dataAccess.Set<Semester>().Find(semester.Id);

            SemesterToEdit.Name = semester.Name;
            SemesterToEdit.Code = semester.Code;
            _dataAccess.SaveChanges();
        }
    }
}