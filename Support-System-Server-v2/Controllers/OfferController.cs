using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Support_System_Server_v2.Controllers
{
    [Authorize]
    [Route("api/offer")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            this._offerService = offerService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Offer> Post(Offer offer)
        {
            offer.DateCreation = TimeZoneHelper.GetSaWesternStandardTime();
            return _offerService.AddOffer(offer);
        }

        [HttpGet]
        [Route("{code}")]
        public ActionResult<ICollection<Offer>> Get(string code)
        {
            return Ok(_offerService.ListOffers(code));
        }

        [HttpGet]
        [Route("find-by-id/{id}")]
        public ActionResult<Offer> GetByCode(int id)
        {
            var semester = _offerService.FindById(id);

            return Ok(semester);
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Offer> Update(Offer offer)
        {
            _offerService.UpdateOffer(offer);

            return Ok(offer);
        }
    }
}
