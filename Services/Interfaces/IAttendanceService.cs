using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAttendanceService
    {
        Attendance AddAttendance(Attendance attendance);
        ICollection<Attendance> ListAttendances();
        void DeleteAttendance(int id);
        void UpdateAttendance(Attendance attendance);
        Attendance GeyById(int id);
    }
}
