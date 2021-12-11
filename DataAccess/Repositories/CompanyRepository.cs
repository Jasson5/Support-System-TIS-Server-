using Authentication.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public Company Add(Company company)
        {
            if (company.Semester != null)
            {
                var semester = _context.Set<Semester>().Find(company.Semester.Code);

                if (semester != null)
                {
                    company.Semester = semester;
                }
            }
            _context.Set<Company>().Add(company);
            _context.SaveChanges();

            return company;
        }

        public void AddUsersCompany(ICollection<UsersCompanies> usersCompanies)
        {
            _context.AddRange(usersCompanies);
            _context.SaveChanges();
        }

        public void Delete(Company company)
        {
            throw new System.NotImplementedException();
        }

        public Company FindByKey(string key)
        {
            var offer = _context.Set<Company>().FromSqlRaw($"dbo.GetCompaniesByKey '{key}'").AsEnumerable().FirstOrDefault();

            return offer;
        }

        public ICollection<Company> List(int status)
        {
            var offers = _context.Set<Company>().FromSqlRaw($"dbo.GetCompanies '{status}'").AsEnumerable();

            return offers.ToList();
        }

        public void Update(Company entity)
        {

            var company = FindByKey(entity.ShortName);

            company.CmpanyStatus = entity.CmpanyStatus;

            _context.SaveChanges();
        }
    }
}
