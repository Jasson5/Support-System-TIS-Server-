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
            return _offerService.AddOffer(offer);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Offer>> Get()
        {
            return Ok(_offerService.ListOffers());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Offer> GetById(int id)
        {
            var offer = _offerService.GeyById(id);

            return Ok(offer);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _offerService.DeleteOffer(id);

            return Ok();
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
