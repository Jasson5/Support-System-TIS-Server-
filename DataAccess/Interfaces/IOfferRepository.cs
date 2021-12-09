using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        Offer Add(Offer offer);
        ICollection<Offer> ListOffers(string code);
        void Update(Offer offer);
    }
}
