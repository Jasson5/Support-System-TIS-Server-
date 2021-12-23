using Authentication.Entities;
using DataAccess.Interfaces;
using DataAccess.Model;
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
            _context.Set<Company>().Remove(company);
            _context.SaveChanges();
        }

        public void DeleteUserCompany(string companyName)
        {
            _context.Set<UsersCompanies>().FromSqlRaw($"dbo.DeleteUserCompany '{companyName}'");
            _context.SaveChanges();
        }

        public Company FindByKey(string key)
        {
            var offer = _context.Set<Company>().FromSqlRaw($"dbo.GetCompaniesByKey '{key}'").AsEnumerable().FirstOrDefault();

            return offer;
        }

        public ICollection<Company> FindBySemester(string code)
        {
            var result = _context.Set<CompanyWithMembers>().FromSqlRaw($"dbo.GetCompaniesBySemester '{code}'").AsNoTracking().AsEnumerable();

            return result
                 .GroupBy(c => c.ShortName)
                 .Select(c => new Company
                 {
                     DateCreation = c.First().DateCreation,
                     ShortName = c.First().ShortName,
                     LongName = c.First().LongName,
                     Society = c.First().Society,
                     Address = c.First().Address,
                     Telephone = c.First().Telephone,
                     CmpanyEmail = c.First().CmpanyEmail,
                     Semester = new Semester { Name = c.First().Name, Code = c.First().Code },
                     Members = c.Select(cm => new User
                     {
                         Id = cm.UserId,
                         GivenName = cm.GivenName,
                         Email = cm.Email,
                         FirstName = cm.FirstName,
                         LastName = cm.LastName
                     }).ToList()
                 }).ToList();
        }

        public ICollection<Company> List(int status)
        {
            var result = _context.Set<CompanyWithMembers>().FromSqlRaw($"dbo.GetCompanies '{status}'").AsNoTracking().AsEnumerable();

            return result
                .GroupBy(c => c.ShortName)
                .Select(c => new Company
                {
                    DateCreation = c.First().DateCreation,
                    ShortName = c.First().ShortName,
                    LongName = c.First().LongName,
                    Society = c.First().Society,
                    Address = c.First().Address,
                    Telephone = c.First().Telephone,
                    CmpanyEmail = c.First().CmpanyEmail,
                    Semester = new Semester { Name = c.First().Name , Code = c.First().Code},
                    Members = c.Select(cm=> new User
                    { 
                        GivenName = cm.GivenName,
                        Email = cm.Email,
                        Role = cm.Role,
                    }).ToList()
                }).ToList();
        }

        public void Update(Company entity)
        {
            var company = _context.Set<Company>()
                .SingleOrDefault(c => c.ShortName == entity.ShortName);

            company.CmpanyStatus = entity.CmpanyStatus;

            _context.SaveChanges();
        }
    }
}
