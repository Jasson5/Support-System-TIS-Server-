using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAnnouncementService
    {
        Announcement AddAnnouncement(Announcement announcement);
        ICollection<Announcement> ListAnnouncements(string code);
        void DeleteAnnouncement(int id);
        void UpdateAnnouncement(Announcement announcement);
        Announcement GeyById(int id);
    }
}
