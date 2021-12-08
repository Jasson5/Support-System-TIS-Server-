using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public Calendar FindById(int id)
        {
            var calendar = _dataAccess.Set<Calendar>().FromSqlRaw($"dbo.GetCalendarById '{id}'").AsEnumerable().SingleOrDefault();

            return calendar;
        }

        public ICollection<Calendar> ListCalendars()
        {
            var calendars = _dataAccess.Set<Calendar>().FromSqlRaw($"dbo.GetCalendars").AsEnumerable();

            return calendars.ToList();
        }

        public void Update(Calendar calendar)
        {
            var CalendarToEdit = _dataAccess.Set<Calendar>().Find(calendar.Id);

            CalendarToEdit.DayDate = calendar.DayDate;
            CalendarToEdit.DayDescription = calendar.DayDescription;
            CalendarToEdit.DayObservation = calendar.DayObservation;
            CalendarToEdit.Company = calendar.Company;
            _dataAccess.SaveChanges();
        }
    }
}