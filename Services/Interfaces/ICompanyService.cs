using Authentication.Entities;
using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICompanyService
    {
        Company AddCompany(Company company);
        ICollection<Company> ListCompanys(int status);
        void DeleteCompany(string key);
        void UpdateCompany(Company company);
        Company FindByKey(string key);
        ICollection<Company> FindBySemester(string code);
    }
}