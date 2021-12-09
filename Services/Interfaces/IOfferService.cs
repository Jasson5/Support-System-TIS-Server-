using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IOfferService
    {
        Offer AddOffer(Offer offer);
        ICollection<Offer> ListOffers(string code);
        void UpdateOffer(Offer offer);
    }
}
