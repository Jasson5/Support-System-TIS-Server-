using Authentication.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface ICompanyRepository
    {
        Company Add(Company company);
        void AddUsersCompany(ICollection<UsersCompanies> usersCompanies);
        ICollection<Company> List(int status);
        void Delete(Company company);
        void DeleteUserCompany(string companyName);
        void Update(Company company);
        Company FindByKey(string key);
        ICollection<Company> FindBySemester(string code);
    }
}
