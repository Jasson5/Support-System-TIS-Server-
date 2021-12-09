using Authentication.Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ISemesterService
    {
        Semester AddSemester(Semester semester);
        ICollection<Semester> ListSemesters();
        ICollection<Semester> ListByUserId(int userId);
        Semester FindByCode(string code);
        void AddUserToSemester(int userId, string semesterCode);

    }
}
