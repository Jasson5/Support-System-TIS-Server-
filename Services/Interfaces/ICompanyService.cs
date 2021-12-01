using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICompanyService
    {
        Company AddCompany(Company company);
        ICollection<Company> ListCompanys();
        void DeleteCompany(int id);
        void UpdateCompany(Company company);
        Company GeyById(int id);
    }
}