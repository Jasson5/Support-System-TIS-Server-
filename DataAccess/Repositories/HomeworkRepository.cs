using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repositories
{
    public class HomeworkRepository : IRepository<Homework>
    {
        private readonly IdentityDbContext _context;

        public HomeworkRepository(IdentityDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Homework> List
        {
            get
            {
                return _context.Set<Homework>();
            }
        }

        public Homework Add(Homework entity)
        {
            _context.Set<Homework>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Homework entity)
        {
            _context.Set<Homework>().Remove(entity);
            _context.SaveChanges();
        }

        public Homework FindById(int id)
        {
            return _context.Set<Homework>().Find(id);
        }

        public Homework FindByIdWithIncludeArray<TInclude>(int id, System.Linq.Expressions.Expression<System.Func<Homework, System.Collections.Generic.ICollection<TInclude>>> includeFunc)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Homework> ListWithInclude<TInclude>(System.Linq.Expressions.Expression<System.Func<Homework, TInclude>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Homework> ListWithIncludeArray<TInclude>(System.Linq.Expressions.Expression<System.Func<Homework, System.Collections.Generic.ICollection<TInclude>>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update(Homework entity)
        {
            /*var matter = _context.Set<Subject>().Find(entity.Id);

            matter.Name = entity.Name;
            matter.Docente = entity.Docente;*/

            _context.SaveChanges();
        }
    }
}
