using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        Offer Add(Offer offer);
        ICollection<Offer> ListOffers();
        void Update(Offer offer);
        Offer FindById(int id);
        void Delete(Offer offer);
    }
}
