using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ISemesterRepository
    {
        Semester Add(Semester semester);
        ICollection<Semester> ListSemesters(string search);
        void Update(Semester semester);
        Semester FindById(int id);
        void Delete(Semester semester);
    }
}
