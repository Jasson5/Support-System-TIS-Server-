using Authentication.Entities;
using DataAccess.Interfaces;
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

        public UserSemesters AddUserToSemester(UserSemesters userSemesters)
        {
            _dataAccess.Set<UserSemesters>().Add(userSemesters);
            _dataAccess.SaveChanges();

            return userSemesters;
        }

        public Semester FindByCode(string code)
        {
            var semester = _dataAccess.Set<Semester>().FromSqlRaw($"dbo.GetSemesterByCode '{code}'").AsEnumerable().SingleOrDefault();


            return semester;
        }

        public ICollection<Semester> List()
        {
            return _dataAccess.Set<Semester>().ToList();  
        }

        public ICollection<Semester> ListByUserId(int userId)
        {
            var semesters = _dataAccess.Set<Semester>().FromSqlRaw($"dbo.GetSemestersByUser '{userId}'").AsEnumerable();

            return semesters.ToList();
        }
    }
}