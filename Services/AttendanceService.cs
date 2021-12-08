using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            this._attendanceRepository = attendanceRepository;
        }
        public Attendance AddAttendance(Attendance attendance)
        {
            var newAttendance = _attendanceRepository.Add(attendance);

            return newAttendance;
        }

        public void DeleteAttendance(int id)
        {
            var attendance = _attendanceRepository.FindById(id);

            if (attendance != null)
            {
                _attendanceRepository.Delete(attendance);
            }
        }


        public Attendance GeyById(int id)
        {
            return _attendanceRepository.FindById(id);
        }

        public ICollection<Attendance> ListAttendances()
        {
            var attendance = _attendanceRepository.ListAttendances();

            return attendance.ToList();
        }

        public void UpdateAttendance(Attendance attendance)
        {
            _attendanceRepository.Update(attendance);
        }
    }
}
