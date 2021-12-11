using Authentication.Entities;
using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
        }
        public Company AddCompany(Company company)
        {
            var result = _companyRepository.FindByKey(company.ShortName);
            var newCompany = new Company();
            if (result != null) 
            {
                newCompany = _companyRepository.Add(company);
                var usersCompanies = new List<UsersCompanies>();
                foreach (var uc in company.Members)
                {
                    var userCompany = new UsersCompanies()
                    {
                        UserId = uc.Id,
                        ShortName = newCompany.ShortName
                    };
                    usersCompanies.Add(userCompany);
                }
                _companyRepository.AddUsersCompany(usersCompanies);
            }
            else
            {
                throw new ApplicationException("La compañia ya existe");
            }

            return newCompany;
        }

        public void DeleteCompany(string key)
        {
            var company = _companyRepository.FindByKey(key);

            if (company != null)
            {
                _companyRepository.Delete(company);
            }
        }


        public Company FindByKey(string key)
        {
            return _companyRepository.FindByKey(key);
        }

        public ICollection<Company> ListCompanys(int status)
        {
            var company = _companyRepository.List(status);

            return company.ToList();
        }

        public void UpdateCompany(Company company)
        {
            _companyRepository.Update(company);
        }
    }
}