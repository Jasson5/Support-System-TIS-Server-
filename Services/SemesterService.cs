using Authentication.DataAccess.Interfaces;
using Authentication.Entities;
using Authentication.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.RequestParameters;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IUserService _userService;

        public SemesterService(ISemesterRepository semesterRepository, IUserService userService)
        {
            this._semesterRepository = semesterRepository;
            this._userService = userService;
        }

        public Semester AddSemester(Semester semester)
        {
            var newSemester = _semesterRepository.Add(semester);

            return newSemester;
        }

        public void AddUserToSemester(int userId, string semesterCode)
        {
            var result = _semesterRepository.FindByIdnCode(semesterCode, userId);
            var userSemester = new UserSemesters();
            if (result != null)
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

        public Semester FindByCode(string code)
        {
            return _semesterRepository.FindByCode(code);
        }

        public ICollection<Semester> ListByUserId(int userId)
        {
            return _semesterRepository.ListByUserId(userId);
        }

        public ICollection<Semester> ListSemesters()
        {
            var semester = _semesterRepository.List();

            return semester.ToList();
        }

        public ICollection<User> ListUsersBySemester(UsersRequestParameters query)
        {
            var users = _semesterRepository.ListUsersBySemester(query.Search, query.Code);

            return users.ToList();
        }
    }
}
