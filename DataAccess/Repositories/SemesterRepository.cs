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

        public void Delete(Semester semester)
        {
            _dataAccess.Set<Semester>().Remove(semester);
            _dataAccess.SaveChanges();
        }

        public Semester FindByCode(string code)
        {
            return _dataAccess.Set<Semester>()
                .SingleOrDefault(s => s.Code == code);
        }

        public ICollection<Semester> List()
        {
            return _dataAccess.Set<Semester>().ToList();  
        }

        public ICollection<Semester> ListByUserId(int userId)
        {
            var offer = _dataAccess.Set<Semester>().FromSqlRaw($"dbo.GetSemestersByUser '{userId}'").AsEnumerable();

            return offer.ToList();
        }
    }
}