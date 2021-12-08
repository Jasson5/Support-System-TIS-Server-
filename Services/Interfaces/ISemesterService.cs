using Authentication.Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ISemesterService
    {
        Semester AddSemester(Semester semester);
        ICollection<Semester> ListSemesters();
        Semester FindById(int id);

    }
}
