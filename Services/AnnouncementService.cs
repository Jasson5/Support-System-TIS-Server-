using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            this._announcementRepository = announcementRepository;
        }
        public Announcement AddAnnouncement(Announcement announcement)
        {
            var newAnnouncement = _announcementRepository.Add(announcement);

            return newAnnouncement;
        }

        public void DeleteAnnouncement(int id)
        {
            var announcement = _announcementRepository.FindById(id);

            if (announcement != null)
            {
                _announcementRepository.Delete(announcement);
            }
        }


        public Announcement GeyById(int id)
        {
            return _announcementRepository.FindById(id);
        }

        public ICollection<Announcement> ListAnnouncements(string code)
        {
            var announcement = _announcementRepository.ListAnnouncements(code);

            return announcement.ToList();
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            _announcementRepository.Update(announcement);
        }
    }
}
