using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ISemesterService
    {
        Semester AddSemester(Semester semester);
        ICollection<Semester> ListSemesters();
        void DeleteSemester(int id);
        void UpdateSemester(Semester semester);
        Semester GeyById(int id);

    }
}
