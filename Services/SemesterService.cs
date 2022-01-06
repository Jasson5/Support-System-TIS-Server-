using Authentication.DataAccess.Interfaces;
using Authentication.Entities;
using Authentication.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.RequestParameters;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

//Logica de Semestre

namespace Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IUserService _userService;

        //Constructor del servicio de Semestre
        public SemesterService(ISemesterRepository semesterRepository, IUserService userService)
        {
            this._semesterRepository = semesterRepository;
            this._userService = userService;
        }

        //Añadir un nuevo semestre
        public Semester AddSemester(Semester semester)
        {
            var newSemester = _semesterRepository.Add(semester);

            return newSemester;
        }

        //Añadir a los usuarios al semestre, en caso de que un estudiante ya este en el semestre y use el codigo para unirse al mismo semestre
        // se mostrara el mensaje de error, que ya pertenece al semestre del codigo proporcionado
        public void AddUserToSemester(int userId, string semesterCode)
        {
            var result = _semesterRepository.FindByIdnCode(semesterCode, userId);
            var userSemester = new UserSemesters();
            if (result == null)
            {
                userSemester.SemesterCode = semesterCode;
                userSemester.UserId = userId;

                _semesterRepository.AddUserToSemester(userSemester);
            }
            else 
            {
                throw new ApplicationException("El usuario ya esta registrado en este semestre");
            }
        }

        //Obtener el semestre por su codigo
        public Semester FindByCode(string code)
        {
            return _semesterRepository.FindByCode(code);
        }

        //Obtener la lista de los estudiantes en un semestre
        public ICollection<Semester> ListByUserId(int userId)
        {
            return _semesterRepository.ListByUserId(userId);
        }

        //Obtener la lista de semestres
        public ICollection<Semester> ListSemesters()
        {
            var semester = _semesterRepository.List();

            return semester.ToList();
        }

        //Busqueda de usuarios en un semestre
        public ICollection<User> ListUsersBySemester(UsersRequestParameters query)
        {
            var users = _semesterRepository.ListUsersBySemester(query.Search, query.Code);

            return users.ToList();
        }
    }
}
