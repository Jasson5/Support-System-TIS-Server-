using Authentication.Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ISemesterRepository
    {
        Semester Add(Semester semester);
        ICollection<Semester> List();
        ICollection<Semester> ListByUserId(int userId);
        Semester FindByCode(string code);
        UserSemesters AddUserToSemester(UserSemesters userSemesters);
        ICollection<User> ListUsersBySemester(string search, string code);

    }
}
