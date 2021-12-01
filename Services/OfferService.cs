using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer> _offerRepository;

        public OfferService(IRepository<Offer> offerRepository)
        {
            this._offerRepository = offerRepository;
        }
        public Offer AddOffer(Offer offer)
        {
            var newOffer = _offerRepository.Add(offer);

            return newOffer;
        }

        public Offer GeyById(int id)
        {
            return _offerRepository.FindById(id);
        }

        public ICollection<Offer> ListOffer()
        {
            var offer = _offerRepository.List;

            return offer.ToList();
        }

        public void UpdateOffer(Offer offer)
        {
            _offerRepository.Update(offer);
        }
    }
}
