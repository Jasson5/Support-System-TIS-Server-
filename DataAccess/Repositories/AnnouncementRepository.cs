using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repositories
{
    public class AnnouncementRepository : IRepository<Announcement>
    {
        private readonly IdentityDbContext _context;

        public AnnouncementRepository(IdentityDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Announcement> List
        {
            get
            {
                return _context.Set<Announcement>();
            }
        }

        public Announcement Add(Announcement entity)
        {
            _context.Set<Announcement>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Announcement entity)
        {
            _context.Set<Announcement>().Remove(entity);
            _context.SaveChanges();
        }

        public Announcement FindById(int id)
        {
            return _context.Set<Announcement>().Find(id);
        }

        public Announcement FindByIdWithIncludeArray<TInclude>(int id, System.Linq.Expressions.Expression<System.Func<Announcement, System.Collections.Generic.ICollection<TInclude>>> includeFunc)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Announcement> ListWithInclude<TInclude>(System.Linq.Expressions.Expression<System.Func<Announcement, TInclude>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Announcement> ListWithIncludeArray<TInclude>(System.Linq.Expressions.Expression<System.Func<Announcement, System.Collections.Generic.ICollection<TInclude>>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update(Announcement entity)
        {
            var announcement = _context.Set<Announcement>().Find(entity.Id);

            announcement.DateAnnouncement = entity.DateAnnouncement;
            announcement.DescriptionAnnouncement = entity.DescriptionAnnouncement;
            announcement.DocumentAnnouncement = entity.DocumentAnnouncement;

            _context.SaveChanges();
        }
    }
}