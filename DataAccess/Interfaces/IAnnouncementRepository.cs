using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IAnnouncementRepository
    {
        //Interface para el repositorio de anuncio
        Announcement Add(Announcement announcement);
        ICollection<Announcement> ListAnnouncements(string code);
        void Update(Announcement announcement);
        Announcement FindById(int id);
        void Delete(Announcement announcement);
    }
}
