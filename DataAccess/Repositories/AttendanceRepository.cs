using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public AttendanceRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Attendance Add(Attendance attendance)
        {
            _dataAccess.Set<Attendance>().Add(attendance);
            _dataAccess.SaveChanges();

            return attendance;
        }

        public void Delete(Attendance attendance)
        {
            _dataAccess.Set<Attendance>().Remove(attendance);
            _dataAccess.SaveChanges();
        }

        public Attendance FindById(int id)
        {
            var attendance = _dataAccess.Set<Attendance>().FromSqlRaw($"dbo.GetAttendanceById '{id}'").AsEnumerable().SingleOrDefault();

            return attendance;
        }

        public ICollection<Attendance> ListAttendances()
        {
            var attendances = _dataAccess.Set<Attendance>().FromSqlRaw($"dbo.GetAttendances").AsEnumerable();

            return attendances.ToList();
        }

        public void Update(Attendance attendance)
        {
            var AttendanceToEdit = _dataAccess.Set<Attendance>().Find(attendance.Id);

            AttendanceToEdit.AttendanceDate = attendance.AttendanceDate;
            AttendanceToEdit.Note = attendance.Note;
            AttendanceToEdit.AttendanceStatus = attendance.AttendanceStatus;
            AttendanceToEdit.AttendanceGrade = attendance.AttendanceGrade;
            AttendanceToEdit.POVGrade = attendance.POVGrade;
            _dataAccess.SaveChanges();
        }
    }
}