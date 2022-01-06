using Authentication.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public SemesterRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Semester Add(Semester semester) //Aniadir semestre
        {
            _dataAccess.Set<Semester>().Add(semester);
            _dataAccess.SaveChanges();

            return semester;
        }

        public UserSemesters AddUserToSemester(UserSemesters userSemesters) //añadir estudiantes a semestre
        {
            _dataAccess.Set<UserSemesters>().Add(userSemesters);
            _dataAccess.SaveChanges();

            return userSemesters;
        }

        public Semester FindByCode(string code) //encontra semestre por codigo
        {
            var semester = _dataAccess.Set<Semester>().FromSqlRaw($"dbo.GetSemesterByCode '{code}'").AsEnumerable().SingleOrDefault();


            return semester;
        }

        public UserSemesters FindByIdnCode(string code, int userId) //Encontra semestre por id y codigo
        {
            var usersemester = _dataAccess.Set<UserSemesters>().FromSqlRaw($"dbo.GetUserSemestersByIdCode '{userId}', '{code}'").AsEnumerable().SingleOrDefault();

            return usersemester;
        }

        public ICollection<Semester> List() //Listar semetsres
        {
            return _dataAccess.Set<Semester>().ToList();  
        }

        public ICollection<Semester> ListByUserId(int userId) //Encontrar semestre por usuario
        {
            var semesters = _dataAccess.Set<Semester>().FromSqlRaw($"dbo.GetSemestersByUser '{userId}'").AsEnumerable();

            return semesters.ToList();
        }

        public ICollection<User> ListUsersBySemester(string search = "", string code = "") //listar usuarios por semestre
        {
            var users = _dataAccess.Set<User>().FromSqlRaw($"dbo.GetUsersByNonSemester '{code}', '{search}'").AsEnumerable();

            return users.ToList();
        }
    }
}