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

        public void DeleteOffer(int id)
        {
            var offer = _offerRepository.FindById(id);

            if (offer != null)
            {
                _offerRepository.Delete(offer);
            }
        }


        public Offer GeyById(int id)
        {
            return _offerRepository.FindById(id);
        }

        public ICollection<Offer> ListOffers()
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
