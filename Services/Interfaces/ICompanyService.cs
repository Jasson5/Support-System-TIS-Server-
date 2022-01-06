using Authentication.Entities;
using Entities;
using System.Collections;
using System.Collections.Generic;

//Interfaces para el servicio de GrupoEmpresa.

namespace Services.Interfaces
{
    public interface ICompanyService
    {
        Company AddCompany(Company company);
        ICollection<Company> ListCompanys(int status);
        void DeleteCompany(string key);
        void UpdateCompany(Company company);
        Company FindByKey(string key);
        Company FindByUserNSemester(int userId, string code);
        ICollection<Company> FindBySemester(string code);
    }
}