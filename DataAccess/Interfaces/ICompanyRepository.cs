using Authentication.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface ICompanyRepository
    {
        Company Add(Company company);
        ICollection<Company> List();
        void Delete(Company company);
        void Update(Company company);
        Company FindById(int id);
    }
}
