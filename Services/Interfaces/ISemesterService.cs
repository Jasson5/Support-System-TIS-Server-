using Authentication.Entities;
using Entities.RequestParameters;
using System.Collections.Generic;

//Interfaces para el servicio de Semestre.

namespace Services.Interfaces
{
    public interface ISemesterService
    {
        Semester AddSemester(Semester semester);
        ICollection<Semester> ListSemesters();
        ICollection<Semester> ListByUserId(int userId);
        Semester FindByCode(string code);
        void AddUserToSemester(int userId, string semesterCode);
        ICollection<User> ListUsersBySemester(UsersRequestParameters query);

    }
}
