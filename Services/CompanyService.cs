using Authentication.Entities;
using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

//Logica de la GrupoEmpresa

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IFinalGradeRepository _finalGradeRepository;

        //Constructor de la GrupoEmpresa
        public CompanyService(ICompanyRepository companyRepository, IFinalGradeRepository finalGradeRepository)
        {
            this._companyRepository = companyRepository;
            this._finalGradeRepository = finalGradeRepository;
        }

        //Añadir una GrupoEmpresa nueva
        public Company AddCompany(Company company)
        {
            //Creación de la grupo empresa por el nombre corto que debe ser único
            var result = _companyRepository.FindByKey(company.ShortName);
            var newCompany = new Company();

            //Se controla que un estudiante no pueda estar dentro de más de una GrupoEmpresa por semestre
            //Si todos lo estudiantes seleccionados para conformar una GrupoEmpresa son Elegibles(Que no pertenezcan a una grupo empresa aún)
            // entonces podra crear y pertenecer a una nueva GrupoEmpresa
            if (result == null) 
            {
                var flag = true;
                foreach (var us in company.Members)
                {
                    var IsElegible = _companyRepository.FindByUSC(company.Semester.Code, us.Id);
                    if (IsElegible != null) {
                        flag = false;
                        break;
                    }
                }
                //Si la grupo empresa es valida a crearse, se creara la grupo empresa añadiendo a los miembros seleccionados 
                // e inicializando sus notas finales en 0 para posterior el Docente las modifique.
                if (flag)
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
                    //En caso de fallar el requisito de que casa Estudiante solo pueda estar en una Grupo empresa se mostrara el error.
                    throw new ApplicationException("Un usuario ya pertenece a una compañia");
                }
            }
            else
            {
                //En caso de intentar crear una Grupo empresa con un nombre ya registrado anteriormente se nos mostara el error
                throw new ApplicationException("La compañia ya existe");
            }

            return newCompany;
        }

        //Eliminar la Grupo Empresa
        //Se elimina la grupo empresa, registro de que los estudiantes estuvieron en esa grupo empresa y sus notas en esa empresa.
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

        //Se busca las grupo empresas por su nombre corto
        public Company FindByKey(string key)
        {
            return _companyRepository.FindByKey(key);
        }

        //Se lista las grupo empresas por el semestre al que pertenecen
        public ICollection<Company> FindBySemester(string code)
        {
            return _companyRepository.FindBySemester(code);
        }

        //Se lista los usuarios de una grupo empresa por Id de Usuario y el codigo del semestre al que pertence
        public Company FindByUserNSemester(int userId, string code)
        {
            return _companyRepository.FindByUserNSemester(userId,code);
        }

        //Se lista las Grupo Empresa por su estado(Aceptadas o Pendientes por el Docente)
        public ICollection<Company> ListCompanys(int status)
        {
            var company = _companyRepository.List(status);

            return company.ToList();
        }

        //Se actualiza una Grupo Empresa
        public void UpdateCompany(Company company)
        {
            _companyRepository.Update(company);
        }
    }
}