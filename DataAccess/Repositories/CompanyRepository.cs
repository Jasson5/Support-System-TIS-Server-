using Authentication.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IdentityDbContext _context;

        public CompanyRepository(IdentityDbContext context)
        {
            this._context = context;
        }

        public Company Add(Company entity)
        {
            _context.Set<Company>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Company company)
        {
            throw new System.NotImplementedException();
        }

        public Company FindById(int id)
        {
            return _context.Set<Company>().Find(id);
        }

        public ICollection<Company> List()
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
