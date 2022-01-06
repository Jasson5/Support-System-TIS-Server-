using Authentication.Entities;
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

        public Announcement Add(Announcement announcement) //aniade publicacion hecha por Administrador
        {
            if (announcement.Semester != null)
            {
                var semester = _dataAccess.Set<Semester>().Find(announcement.Semester.Code);

                if (semester != null)
                {
                    announcement.Semester = semester;
                }
            }

            _dataAccess.Set<Announcement>().Add(announcement);
            _dataAccess.SaveChanges();

            return announcement;
        }

        public void Delete(Announcement announcement) //Borra publicacion hecha por Administrador
        {
            _dataAccess.Set<Announcement>().Remove(announcement);
            _dataAccess.SaveChanges();
        }

        public Announcement FindById(int id) //Encuentra publicacion por Id
        {
            var announcement = _dataAccess.Set<Announcement>().FromSqlRaw($"dbo.GetAnnouncementById '{id}'").AsEnumerable().SingleOrDefault();

            return announcement;
        }

        public ICollection<Announcement> ListAnnouncements(string code) //Lista publicaciones 
        {
            var announcements = _dataAccess.Set<Announcement>().FromSqlRaw($"dbo.GetAnnouncementBySemester '{code}'").AsEnumerable();

            return announcements.ToList();
        }

        public void Update(Announcement announcement) //Actualiza publicaciones
        {
            var AnnouncementToEdit = _dataAccess.Set<Announcement>().Find(announcement.Id);

            AnnouncementToEdit.Description = announcement.Description;
            AnnouncementToEdit.DocumentUrl = announcement.DocumentUrl;
            _dataAccess.SaveChanges();   
        }
    }
}