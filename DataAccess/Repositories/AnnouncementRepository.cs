using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public AnnouncementRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Announcement Add(Announcement announcement)
        {
            _dataAccess.Set<Announcement>().Add(announcement);
            _dataAccess.SaveChanges();

            return announcement;
        }

        public void Delete(Announcement announcement)
        {
            _dataAccess.Set<Announcement>().Remove(announcement);
            _dataAccess.SaveChanges();
        }

        public Announcement FindById(int id)
        {
            var announcement = _dataAccess.Set<Announcement>().FromSqlRaw($"dbo.GetAnnouncementById '{id}'").AsEnumerable().SingleOrDefault();

            return announcement;
        }

        public ICollection<Announcement> ListAnnouncements() 
        {
            var announcements = _dataAccess.Set<Announcement>().FromSqlRaw($"dbo.GetAnnouncements").AsEnumerable();

            return announcements.ToList();
        }

        public void Update(Announcement announcement) 
        {
            var AnnouncementToEdit = _dataAccess.Set<Announcement>().Find(announcement.Id);

            AnnouncementToEdit.Description = announcement.Description;
            AnnouncementToEdit.DocumentUrl = announcement.DocumentUrl;
            _dataAccess.SaveChanges();   
        }
    }
}