using Authentication.Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ISemesterRepository
    {
        Semester Add(Semester semester);
        ICollection<Semester> List();
        Semester FindById(int id);
    }
}
