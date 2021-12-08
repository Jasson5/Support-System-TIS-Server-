using Authentication.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            throw new System.NotImplementedException();
        }

        public ICollection<Semester> List()
        {
            return _dataAccess.Set<Semester>().ToList();  
        }
    }
}