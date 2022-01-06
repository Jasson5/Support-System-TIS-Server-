using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

//Logica de Anuncios

namespace Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        //Constructor de la clase Servicio de Anuncio
        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            this._announcementRepository = announcementRepository;
        }

        //Añadir un Anuncio nuevo
        public Announcement AddAnnouncement(Announcement announcement)
        {
            var newAnnouncement = _announcementRepository.Add(announcement);

            return newAnnouncement;
        }

        //Eliminar un Anuncio existente por su ID
        public void DeleteAnnouncement(int id)
        {
            var announcement = _announcementRepository.FindById(id);

            if (announcement != null)
            {
                _announcementRepository.Delete(announcement);
            }
        }

        //Obtener un Anuncio por su ID
        public Announcement GeyById(int id)
        {
            return _announcementRepository.FindById(id);
        }

        //Listar los Anuncios por el codigo de semestre
        public ICollection<Announcement> ListAnnouncements(string code)
        {
            var announcement = _announcementRepository.ListAnnouncements(code);

            return announcement.ToList();
        }

        //Actualizar un Anuncio
        public void UpdateAnnouncement(Announcement announcement)
        {
            _announcementRepository.Update(announcement);
        }
    }
}
