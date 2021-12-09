using Authentication.Entities;
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
            if (offer.Semester != null)
            {
                var semester = _dataAccess.Set<Semester>().Find(offer.Semester.Code);

                if (semester != null)
                {
                    offer.Semester = semester;
                }
            }

            _dataAccess.Set<Offer>().Add(offer);
            _dataAccess.SaveChanges();

            return offer;
        }

        public ICollection<Offer> ListOffers(string code)
        {
            var offers = _dataAccess.Set<Offer>().FromSqlRaw($"dbo.GetOfferBySemester '{code}'").AsEnumerable();

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
