using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections;
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
            return _companyService.AddCompany(company);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Company>> Get()
        {
            return Ok(_companyService.ListCompanys());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Company> GetById(int id)
        {
            var company = _companyService.GeyById(id);

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
