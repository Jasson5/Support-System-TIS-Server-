using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public CalendarRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Calendar Add(Calendar calendar)
        {
            _dataAccess.Set<Calendar>().Add(calendar);
            _dataAccess.SaveChanges();

            return calendar;
        }

        public void Delete(Calendar calendar)
        {
            _dataAccess.Set<Calendar>().Remove(calendar);
            _dataAccess.SaveChanges();
        }

        public Calendar FindByDate(DateTime date, string Shortname)
        {
            var calendar = _dataAccess.Set<Calendar>().FromSqlRaw($"dbo.GetCalendarByDatenCompany '{date.ToString("MM/dd/yyyy")}', '{Shortname}'").AsEnumerable().FirstOrDefault();

            return calendar;
        }

        public Calendar FindById(int id)
        {
            var calendar = _dataAccess.Set<Calendar>().FromSqlRaw($"dbo.GetCalendarById '{id}'").AsEnumerable().SingleOrDefault();

            return calendar;
        }

        public ICollection<Calendar> ListCalendars(string companyName)
        {
            var calendars = _dataAccess.Set<Calendar>().FromSqlRaw($"dbo.GetCalendarByCompany  '{companyName}'").AsEnumerable();

            return calendars.ToList();
        }

        public void Update(Calendar calendar)
        {
            var CalendarToEdit = _dataAccess.Set<Calendar>().Find(calendar.Id);

            CalendarToEdit.DayDate = calendar.DayDate;
            CalendarToEdit.DayDescription = calendar.DayDescription;
            CalendarToEdit.DayObservation = calendar.DayObservation;
            CalendarToEdit.CompanyName = calendar.CompanyName;
            _dataAccess.SaveChanges();
        }
    }
}