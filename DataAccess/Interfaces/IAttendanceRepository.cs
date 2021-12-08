using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IAttendanceRepository
    {
        Attendance Add(Attendance attendance);
        ICollection<Attendance> ListAttendances();
        void Update(Attendance attendance);
        Attendance FindById(int id);
        void Delete(Attendance attendance);
    }
}
