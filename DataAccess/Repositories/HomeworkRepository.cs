using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public HomeworkRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Homework Add(Homework homework)
        {
            _dataAccess.Set<Homework>().Add(homework);
            _dataAccess.SaveChanges();

            return homework;
        }

        public void Delete(Homework homework)
        {
            _dataAccess.Set<Homework>().Remove(homework);
            _dataAccess.SaveChanges();
        }

        public Homework FindByTittle(string tittle)
        {
            var homework = _dataAccess.Set<Homework>().FromSqlRaw($"dbo.GetHomeworkByTittle '{tittle}'").AsEnumerable().SingleOrDefault();

            return homework;
        }

        public Homework FindById(int id)
        {
            var homework = _dataAccess.Set<Homework>().FromSqlRaw($"dbo.GetHomeworkById '{id}'").AsEnumerable().SingleOrDefault();

            return homework;
        }

        public ICollection<Homework> ListHomeworks(string search)
        {
            var homeworks = _dataAccess.Set<Homework>().FromSqlRaw($"dbo.GetHomeworks'{search}'").AsEnumerable();

            return homeworks.ToList();
        }

        public void Update(Homework homework)
        {
            var HomeworkToEdit = _dataAccess.Set<Homework>().Find(homework.Id);

            HomeworkToEdit.Tittle = homework.Tittle;
            HomeworkToEdit.Description = homework.Description;
            HomeworkToEdit.HomeworkFileLink = homework.HomeworkFileLink;
            HomeworkToEdit.DeliveryDate = homework.DeliveryDate;
            HomeworkToEdit.HomeworkStatus = homework.HomeworkStatus;
            HomeworkToEdit.Grade = homework.Grade;

            _dataAccess.SaveChanges();
        }
    }
}
