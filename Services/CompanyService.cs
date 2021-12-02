using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            this._companyRepository = companyRepository;
        }
        public Company AddCompany(Company company)
        {
            var newCompany = _companyRepository.Add(company);

            return newCompany;
        }

        public void DeleteCompany(int id)
        {
            var company = _companyRepository.FindById(id);

            if (company != null)
            {
                _companyRepository.Delete(company);
            }
        }


        public Company GeyById(int id)
        {
            return _companyRepository.FindById(id);
        }

        public ICollection<Company> ListCompanys()
        {
            var company = _companyRepository.List;

            return company.ToList();
        }

        public void UpdateCompany(Company company)
        {
            _companyRepository.Update(company);
        }
    }
}