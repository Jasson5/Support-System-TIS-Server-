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
        private readonly IFinalGradeRepository _finalGradeRepository;

        public CompanyService(ICompanyRepository companyRepository, IFinalGradeRepository finalGradeRepository)
        {
            this._companyRepository = companyRepository;
            this._finalGradeRepository = finalGradeRepository;
        }
        public Company AddCompany(Company company)
        {
            var result = _companyRepository.FindByKey(company.ShortName);
            var newCompany = new Company();
            if (result == null) 
            {
                newCompany = _companyRepository.Add(company);
                var usersCompanies = new List<UsersCompanies>();
                var finalGrades = new List<FinalGrade>();
                foreach (var uc in company.Members)
                {
                    var userCompany = new UsersCompanies()
                    {
                        UserId = uc.Id,
                        ShortName = newCompany.ShortName,
                        Role = uc.Roles.First().Name,
                        SemesterCode = company.Semester.Code
                    };
                    usersCompanies.Add(userCompany);
                    var finalGrade = new FinalGrade()
                    {
                        DateCreation = (DateTime)company.DateCreation,
                        CompanyName = newCompany.ShortName,
                        UserId = uc.Id,
                        Grade = 0
                    };
                    finalGrades.Add(finalGrade);
                }
                _companyRepository.AddUsersCompany(usersCompanies);
                _finalGradeRepository.Add(finalGrades);
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
                try
                {
                    _companyRepository.DeleteUserCompany(key);
                    _companyRepository.Delete(company);
                    _finalGradeRepository.Delete(key);
                } 
                catch (Exception exception)
                {
                    throw new ApplicationException(exception.Message);
                }
            }
        }


        public Company FindByKey(string key)
        {
            return _companyRepository.FindByKey(key);
        }

        public ICollection<Company> FindBySemester(string code)
        {
            return _companyRepository.FindBySemester(code);
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