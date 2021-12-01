using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IRepository<Calendar> _calendarRepository;

        public CalendarService(IRepository<Calendar> calendarRepository)
        {
            this._calendarRepository = calendarRepository;
        }
        public Calendar AddCalendar(Calendar calendar)
        {
            var newCalendar = _calendarRepository.Add(calendar);

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
            var calendar = _calendarRepository.List;

            return calendar.ToList();
        }

        public void UpdateCalendar(Calendar calendar)
        {
            _calendarRepository.Update(calendar);
        }
    }
}
