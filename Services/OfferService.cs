using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

//Logica de Convocatoria

namespace Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        //Constructor de los servicios de convocatoria
        public OfferService(IOfferRepository offerRepository)
        {
            this._offerRepository = offerRepository;
        }

        //Añadir una Convocatoria nueva
        public Offer AddOffer(Offer offer)
        {
            var newOffer = _offerRepository.Add(offer);

            return newOffer;
        }

        //Obtener una convocatoria por el ID
        public Offer FindById(int id)
        {
            var offer = _offerRepository.FindById(id);

            return offer;
        }

        //Listar las convocatorias por el codigo del semestre
        public ICollection<Offer> ListOffers(string code)
        {
            var offer = _offerRepository.ListOffers(code);

            return offer.ToList();
        }

        //Actualiza una convocatoria existente
        public void UpdateOffer(Offer offer)
        {
            _offerRepository.Update(offer);
        }
    }
}
