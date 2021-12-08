using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public OfferRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Offer Add(Offer offer)
        {
            _dataAccess.Set<Offer>().Add(offer);
            _dataAccess.SaveChanges();

            return offer;
        }

        public void Delete(Offer offer)
        {
            _dataAccess.Set<Offer>().Remove(offer);
            _dataAccess.SaveChanges();
        }

        public Offer FindById(int id)
        {
            var offer = _dataAccess.Set<Offer>().FromSqlRaw($"dbo.GetOfferById '{id}'").AsEnumerable().SingleOrDefault();

            return offer;
        }

        public ICollection<Offer> ListOffers(string search)
        {
            var offers = _dataAccess.Set<Offer>().FromSqlRaw($"dbo.GetOffers'{search}'").AsEnumerable();

            return offers.ToList();
        }

        public void Update(Offer offer)
        {
            var OfferToEdit = _dataAccess.Set<Offer>().Find(offer.Id);

            OfferToEdit.Description = offer.Description;
            OfferToEdit.DateEnd = offer.DateEnd;
            OfferToEdit.Semester = offer.Semester;
            OfferToEdit.DocumentOfferUrl = offer.DocumentOfferUrl;
            OfferToEdit.MinUsers = offer.MinUsers;
            OfferToEdit.MaxUsers = offer.MaxUsers;
            _dataAccess.SaveChanges();
        }
    }
}
