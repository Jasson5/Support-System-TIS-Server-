using Authentication.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly IdentityDbContext _context;

        public SemesterRepository(IdentityDbContext context)
        {
            this._context = context;
        }

        public Semester Add(Semester entity)
        {
            _context.Set<Semester>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Semester FindById(int id)
        {
            return _context.Set<Semester>().Find(id);
        }

        public ICollection<Semester> List()
        {
            return _context.Set<Semester>().ToList();            
        }
    }
}
