using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<Announcement> _announcementRepository;

        public AnnouncementService(IRepository<Announcement> announcementRepository)
        {
            this._announcementRepository = announcementRepository;
        }
        public Announcement AddAnnouncement(Announcement announcement)
        {
            var newAnnouncement = _announcementRepository.Add(announcement);

            return newAnnouncement;
        }

        public Announcement GeyById(int id)
        {
            return _announcementRepository.FindById(id);
        }

        public ICollection<Announcement> ListAnnouncement()
        {
            var announcement = _announcementRepository.List;

            return announcement.ToList();
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            _announcementRepository.Update(announcement);
        }
    }
}
