using Authentication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections.Generic;

namespace Support_System_Server_v2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("{statusId}")]
        public ActionResult<ICollection<Company>> Get(int statusId)
        {
            return Ok(_companyService.ListCompanys(statusId));
        }

        [HttpGet]
        [Route("find-by-id/{id}")]
        public ActionResult<Company> GetById(int id)
        {
            var company = _companyService.FindById(id);

            return Ok(company);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _companyService.DeleteCompany(id);

            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Company> Update(Company company)
        {
            _companyService.UpdateCompany(company);

            return Ok(company);
        }

    }
}
