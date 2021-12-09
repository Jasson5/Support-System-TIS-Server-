using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this._offerRepository = offerRepository;
        }
        public Offer AddOffer(Offer offer)
        {
            var newOffer = _offerRepository.Add(offer);

            return newOffer;
        }

        public ICollection<Offer> ListOffers(string code)
        {
            var offer = _offerRepository.ListOffers(code);

            return offer.ToList();
        }

        public void UpdateOffer(Offer offer)
        {
            _offerRepository.Update(offer);
        }
    }
}
