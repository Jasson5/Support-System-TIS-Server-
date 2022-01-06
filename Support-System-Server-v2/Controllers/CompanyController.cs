using Authentication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections.Generic;

//Endpoints de Grupo Empresa

namespace Support_System_Server_v2.Controllers
{
    [Authorize]
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            this._companyService = companyService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Company> Post(Company company)
        {
            company.DateCreation = TimeZoneHelper.GetSaWesternStandardTime();
            return _companyService.AddCompany(company);
        }

        //Get/Obtener empresas por el estado(1/2 sea pendiente o aceptada)
        [HttpGet]
        [Route("{statusId}")]
        public ActionResult<ICollection<Company>> Get(int statusId)
        {
            return Ok(_companyService.ListCompanys(statusId));
        }

        //Get/Obtener empresa por el codigo por nombre corto
        [HttpGet]
        [Route("find-by-id/{key}")]
        public ActionResult<Company> GetByKey(string key)
        {
            var company = _companyService.FindByKey(key);

            return Ok(company);
        }

        //Get/Obtener empresas por el codigo del semestre
        [HttpGet]
        [Route("find-by-semester/{code}")]
        public ActionResult<Company> GetBySemester(string code)
        {
            var company = _companyService.FindBySemester(code);

            return Ok(company);
        }

        //Get/Obtener Estudiantes y su compañia segun el codigo de semestre y ID de usuario
        [HttpGet]
        [Route("user-and-company/{userId}/{code}")]
        public ActionResult<Company> GetBySemester(int userId,string code)
        {
            var company = _companyService.FindByUserNSemester(userId,code);

            return Ok(company);
        }

        //Delete/Eliminar grupo empresa por nombre corto de la empresa
        [HttpDelete]
        [Route("{key}")]
        public ActionResult Delete(string key)
        {
            _companyService.DeleteCompany(key);

            return Ok();
        }

        //Patch/Actualizar grupo empresa
        [HttpPatch]
        [Route("")]
        public ActionResult<Company> Update(Company company)
        {
            _companyService.UpdateCompany(company);

            return Ok(company);
        }

    }
}
