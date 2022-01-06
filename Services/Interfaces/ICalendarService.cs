using Entities;
using System;
using System.Collections;
using System.Collections.Generic;

//Interfaces para el servicio de Calendario.

namespace Services.Interfaces
{
    public interface ICalendarService
    {
        Calendar AddCalendar(Calendar calendar);
        ICollection<Calendar> ListCalendars(string companyName);
        void DeleteCalendar(int id);
        void UpdateCalendar(Calendar calendar);
        Calendar GeyById(string companyName, DateTime date);
    }
}