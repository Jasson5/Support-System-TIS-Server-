using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        //Interface para el repositorio de convocatoria
        Offer Add(Offer offer);
        ICollection<Offer> ListOffers(string code);
        void Update(Offer offer);
        Offer FindById(int id);
    }
}
