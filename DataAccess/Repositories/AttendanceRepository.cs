using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repositories
{
    public class AttendanceRepository : IRepository<Attendance>
    {
        private readonly IdentityDbContext _context;

        public AttendanceRepository(IdentityDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Attendance> List
        {
            get
            {
                return _context.Set<Attendance>();
            }
        }

        public Attendance Add(Attendance entity)
        {
            _context.Set<Attendance>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Attendance entity)
        {
            _context.Set<Attendance>().Remove(entity);
            _context.SaveChanges();
        }

        public Attendance FindById(int id)
        {
            return _context.Set<Attendance>().Find(id);
        }

        public Attendance FindByIdWithIncludeArray<TInclude>(int id, System.Linq.Expressions.Expression<System.Func<Attendance, System.Collections.Generic.ICollection<TInclude>>> includeFunc)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Attendance> ListWithInclude<TInclude>(System.Linq.Expressions.Expression<System.Func<Attendance, TInclude>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Attendance> ListWithIncludeArray<TInclude>(System.Linq.Expressions.Expression<System.Func<Attendance, System.Collections.Generic.ICollection<TInclude>>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update(Attendance entity)
        {
            /*var matter = _context.Set<Subject>().Find(entity.Id);

            matter.Name = entity.Name;
            matter.Docente = entity.Docente;*/

            _context.SaveChanges();
        }
    }
}
