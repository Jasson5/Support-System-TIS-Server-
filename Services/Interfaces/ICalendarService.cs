using Entities;
using System.Collections;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICalendarService
    {
        Calendar AddCalendar(Calendar calendar);
        ICollection<Calendar> ListCalendars();
        void DeleteCalendar(int id);
        void UpdateCalendar(Calendar calendar);
        Calendar GeyById(int id);
    }
}