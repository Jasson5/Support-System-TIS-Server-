using Authentication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections.Generic;

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

        [HttpGet]
        [Route("{statusId}")]
        public ActionResult<ICollection<Company>> Get(int statusId)
        {
            return Ok(_companyService.ListCompanys(statusId));
        }

        [HttpGet]
        [Route("find-by-id/{key}")]
        public ActionResult<Company> GetByKey(string key)
        {
            var company = _companyService.FindByKey(key);

            return Ok(company);
        }

        [HttpDelete]
        [Route("{key}")]
        public ActionResult Delete(string key)
        {
            _companyService.DeleteCompany(key);

            return Ok();
        }

        [HttpPatch]
        [Route("")]
        public ActionResult<Company> Update(Company company)
        {
            _companyService.UpdateCompany(company);

            return Ok(company);
        }

    }
}
