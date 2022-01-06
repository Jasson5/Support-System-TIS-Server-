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

        public Company Add(Company company) //Aniade compania
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

        public void AddUsersCompany(ICollection<UsersCompanies> usersCompanies) //Aniade usuarios a la compania
        {
            _context.AddRange(usersCompanies);
            _context.SaveChanges();
        }

        public void Delete(Company company) //Elimina Compania
        {
            _context.Set<Company>().Remove(company);
            _context.SaveChanges();
        }

        public void DeleteUserCompany(string ShortName) //Elimina usuario de una compania por su nombre corto 
        {
            var userdelete = _context.Set<UsersCompanies>().FromSqlRaw($"dbo.DeleteUserCompany '{ShortName}'").AsEnumerable().ToList();
            
                _context.Set<UsersCompanies>().RemoveRange(userdelete);
                _context.SaveChanges();
        }

        public Company FindByKey(string key) //Encontrar campania por su clave primaria (nombre corto)
        {
            var offer = _context.Set<Company>().FromSqlRaw($"dbo.GetCompaniesByKey '{key}'").AsEnumerable().FirstOrDefault();

            return offer;
        }

        public ICollection<Company> FindBySemester(string code) //Listar companias por semestre
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

        //
        public UsersCompanies FindByUSC(string code, int userId) //Obtener datos de UserCompanies (usarios en compañias)
        {
            var result = _context.Set<UsersCompanies>().FromSqlRaw($"dbo.GetUsersinCompanies '{code}', '{userId}'").AsEnumerable().FirstOrDefault();

            return result;
        }

        public Company FindByUserNSemester(int userId, string code) //Encontrar compania por usuario y semestre
        {
            var result = _context.Set<CompanyWithMembers>().FromSqlRaw($"dbo.GetCompaniesBySemester '{userId}','{code}'").AsNoTracking().AsEnumerable();

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
                 }).ToList().FirstOrDefault();
        }

        public ICollection<Company> List(int status) //Lista de companias
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

        public void Update(Company entity) //Actualizar companias
        {
            var company = _context.Set<Company>()
                .SingleOrDefault(c => c.ShortName == entity.ShortName);

            company.CmpanyStatus = entity.CmpanyStatus;

            _context.SaveChanges();
        }
    }
}
