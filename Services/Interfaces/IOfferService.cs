using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IOfferService
    {
        Offer AddOffer(Offer offer);
        ICollection<Offer> ListOffers();
        void DeleteOffer(int id);
        void UpdateOffer(Offer offer);
        Offer GeyById(int id);
    }
}
