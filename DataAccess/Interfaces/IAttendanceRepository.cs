using System;
using DataAccess.Model;
using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IAttendanceRepository
    {
        Attendance Add(Attendance attendance);
        ICollection<Attendance> ListAttendances();
        ICollection<Attendance> ListAttendancesByCompany(string companyName);
        ICollection<GradeAverageVM> ListGradesByCompany(string companyName);
        void Update(Attendance attendance);
        Attendance FindById(int id);
        Attendance FindByDate(DateTime date, int userId);
        void Delete(Attendance attendance);
    }
}
