using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repositories
{
    public class OfferRepository : IRepository<Offer>
    {
        private readonly IdentityDbContext _context;

        public OfferRepository(IdentityDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Offer> List
        {
            get
            {
                return _context.Set<Offer>();
            }
        }

        public Offer Add(Offer entity)
        {
            _context.Set<Offer>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Offer entity)
        {
            _context.Set<Offer>().Remove(entity);
            _context.SaveChanges();
        }

        public Offer FindById(int id)
        {
            return _context.Set<Offer>().Find(id);
        }

        public Offer FindByIdWithIncludeArray<TInclude>(int id, System.Linq.Expressions.Expression<System.Func<Offer, System.Collections.Generic.ICollection<TInclude>>> includeFunc)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Offer> ListWithInclude<TInclude>(System.Linq.Expressions.Expression<System.Func<Offer, TInclude>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Offer> ListWithIncludeArray<TInclude>(System.Linq.Expressions.Expression<System.Func<Offer, System.Collections.Generic.ICollection<TInclude>>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update(Offer entity)
        {
            var offer = _context.Set<Offer>().Find(entity.Id);
            /*
            matter.Name = entity.Name;
            matter.Docente = entity.Docente;*/
            offer.TitleOffer = entity.TitleOffer;
            offer.DescriptionOffer = entity.DescriptionOffer;
            offer.DateEndOffer = entity.DateEndOffer;
            offer.Semester = entity.Semester;
            offer.DocuementOffer = entity.DocuementOffer;
            offer.minUsers = entity.minUsers;
            offer.maxUsers = entity.maxUsers;

            _context.SaveChanges();
        }
    }
}
