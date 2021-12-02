using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly IdentityDbContext _context;

        public CompanyRepository(IdentityDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Company> List
        {
            get
            {
                return _context.Set<Company>();
            }
        }

        public Company Add(Company entity)
        {
            _context.Set<Company>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Company entity)
        {
            _context.Set<Company>().Remove(entity);
            _context.SaveChanges();
        }

        public Company FindById(int id)
        {
            return _context.Set<Company>().Find(id);
        }

        public Company FindByIdWithIncludeArray<TInclude>(int id, System.Linq.Expressions.Expression<System.Func<Company, System.Collections.Generic.ICollection<TInclude>>> includeFunc)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Company> ListWithInclude<TInclude>(System.Linq.Expressions.Expression<System.Func<Company, TInclude>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Company> ListWithIncludeArray<TInclude>(System.Linq.Expressions.Expression<System.Func<Company, System.Collections.Generic.ICollection<TInclude>>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update(Company entity)
        {
            var company = _context.Set<Company>()
                .FirstOrDefault(c => c.Id == entity.Id);

            company.CmpanyStatus = entity.CmpanyStatus;

            _context.SaveChanges();
        }
    }
}
