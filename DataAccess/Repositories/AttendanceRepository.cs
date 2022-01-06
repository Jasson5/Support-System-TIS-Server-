using Authentication.Entities;
using DataAccess.Interfaces;
using DataAccess.Model;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
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

        public Attendance Add(Attendance attendance) //aniade asistencia hecha por Administrador
        {
            if (attendance.User != null)
            {
                var user = _dataAccess.Set<User>().Find(attendance.User.Id);

                if (user != null)
                {
                    attendance.User = user;
                }
            }
            _dataAccess.Set<Attendance>().Add(attendance);
            _dataAccess.SaveChanges();

            return attendance;
        }

        public void Delete(Attendance attendance) //Borra asistencia hecha por Administrador
        {
            _dataAccess.Set<Attendance>().Remove(attendance);
            _dataAccess.SaveChanges();
        }

        public Attendance FindByDate(DateTime date, int userId) //Encuentra asistencia por fecha 
        {
            var attendance = _dataAccess.Set<Attendance>().FromSqlRaw($"dbo.GetAttendanceByDatenUser '{date.ToString("MM/dd/yyyy")}', '{userId}'").AsEnumerable().SingleOrDefault();

            return attendance;
        }

        public Attendance FindById(int id) //Encuentra asistencia por Id
        {
            var attendance = _dataAccess.Set<Attendance>().FromSqlRaw($"dbo.GetAttendanceById '{id}'").AsEnumerable().SingleOrDefault();

            return attendance;
        }

        public ICollection<Attendance> ListAttendances() // Lista asitencias
        {
            var attendances = _dataAccess.Set<Attendance>().FromSqlRaw($"dbo.GetAttendances").AsEnumerable();

            return attendances.ToList();
        }

        public ICollection<Attendance> ListAttendancesByCompany(string companyName) //Lista las asistencias en funcion a la compania especificada
        {
            var result = _dataAccess.Set<AttendanceWithUser>().FromSqlRaw($"dbo.GetAttendanceByCompany '{companyName}'").AsEnumerable();

            return result.Select(a => new Attendance
            {
                Id = a.Id,
                AttendanceDate = a.AttendanceDate,
                AttendanceStatus = a.AttendanceStatus,
                AttendanceGrade = a.AttendanceGrade,
                CompanyName = a.CompanyName,
                User = new User { Id = a.UserId, GivenName = a.GivenName}
            }).ToList();
        }

        public ICollection<GradeAverageVM> ListGradesByCompany(string companyName) //Da las notas en funcion a la compania
        {
            var gradeAverage = _dataAccess.Set<GradeAverageVM>().FromSqlRaw($"dbo.GetAverageByAttendance '{companyName}'").AsEnumerable();

            return gradeAverage.ToList();
        }

        public void Update(Attendance attendance)//Actualiza asistencia
        {
            var AttendanceToEdit = _dataAccess.Set<Attendance>().Find(attendance.Id);

            AttendanceToEdit.AttendanceDate = attendance.AttendanceDate;
            AttendanceToEdit.AttendanceStatus = attendance.AttendanceStatus;
            AttendanceToEdit.AttendanceGrade = attendance.AttendanceGrade;
            _dataAccess.SaveChanges();
        }
    }
}