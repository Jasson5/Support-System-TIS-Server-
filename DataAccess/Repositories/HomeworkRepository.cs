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

        public Homework Add(Homework homework) //Aniadir tarea
        {
            _dataAccess.Set<Homework>().Add(homework);
            _dataAccess.SaveChanges();

            return homework;
        }

        public void Delete(Homework homework) //Eliminar tarea
        {
            _dataAccess.Set<Homework>().Remove(homework);
            _dataAccess.SaveChanges();
        }

        public Homework FindById(int id) //Encontrar tarea por Id 
        {
            var homework = _dataAccess.Set<Homework>().FromSqlRaw($"dbo.GetHomeworkById '{id}'").AsEnumerable().SingleOrDefault();

            return homework;
        }

        public ICollection<Homework> ListHomeworks()//Listar tareas
        {
            var homeworks = _dataAccess.Set<Homework>().FromSqlRaw($"dbo.GetHomeworks").AsEnumerable();

            return homeworks.ToList();
        }

        public void Update(Homework homework) //Actualizar tareas
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
