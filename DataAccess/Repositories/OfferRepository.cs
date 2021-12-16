using Authentication.Entities;
using DataAccess.Interfaces;
using DataAccess.Model;
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

        public Offer FindById(int id)
        {
            var result = _dataAccess.Set<OfferWithSemester>().FromSqlRaw($"dbo.GetOfferById '{id}'").AsEnumerable().SingleOrDefault();
            var offer = new Offer
            {
                Id = result.id,
                Description = result.Description,
                DateEnd = result.DateEnd,
                DocumentOfferUrl = result.DocumentOfferUrl,
                MinUsers = result.MinUsers,
                MaxUsers = result.MaxUsers,
                Semester = new Semester { Code = result.SemesterCode}
            };

            return offer;
        }

        public ICollection<Offer> ListOffers(string code)
        {
            var offers = _dataAccess.Set<OfferWithSemester>().FromSqlRaw($"dbo.GetOfferBySemester '{code}'").AsEnumerable();

            return offers.Select(o => new Offer
            {
                Id = o.id,
                DateCreation = o.DateCreation,
                Description = o.Description,
                DateEnd = o.DateEnd,
                DocumentOfferUrl = o.DocumentOfferUrl,
                MinUsers = o.MinUsers,
                MaxUsers = o.MaxUsers,
                Semester = new Semester { Code = o.SemesterCode }
            }).ToList();
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
