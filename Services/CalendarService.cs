using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _calendarRepository;

        public CalendarService(ICalendarRepository calendarRepository)
        {
            this._calendarRepository = calendarRepository;
        }
        public Calendar AddCalendar(Calendar calendar)
        {
            var result = _calendarRepository.FindByDate(calendar.DayDate, calendar.CompanyName);
            var newCalendar = new Calendar();
            if (result == null)
            {
                newCalendar = _calendarRepository.Add(calendar);
            }
            else
            {
                throw new ApplicationException("El calendario en la fecha dada ya existe");
            }

            return newCalendar;
        }

        public void DeleteCalendar(int id)
        {
            var calendar = _calendarRepository.FindById(id);

            if (calendar != null)
            {
                _calendarRepository.Delete(calendar);
            }
        }


        public Calendar GeyById(int id)
        {
            return _calendarRepository.FindById(id);
        }

        public ICollection<Calendar> ListCalendars()
        {
            var calendar = _calendarRepository.ListCalendars();

            return calendar.ToList();
        }

        public void UpdateCalendar(Calendar calendar)
        {
            _calendarRepository.Update(calendar);
        }
    }
}
