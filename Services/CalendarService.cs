using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

//Logica del Calendario

namespace Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _calendarRepository;

        //Constructor del servicio de calendario
        public CalendarService(ICalendarRepository calendarRepository)
        {
            this._calendarRepository = calendarRepository;
        }

        //Añadir Calendario nuevo
        public Calendar AddCalendar(Calendar calendar)
        {
            //Creación de Calendario por fecha y compañia, se controla que exista solo uno por fecha.
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

        //Eliminar un calendario por ID
        public void DeleteCalendar(int id)
        {
            var calendar = _calendarRepository.FindById(id);

            if (calendar != null)
            {
                _calendarRepository.Delete(calendar);
            }
        }

        //Obtener un calendario por ID
        public Calendar GeyById(string companyName, DateTime date)
        {
            return _calendarRepository.FindByDate(date, companyName);
        }

        //Listar los calendarios(anotaciones semanales) por nombre corto de la GrupoEmpresa
        public ICollection<Calendar> ListCalendars(string companyName)
        {
            var calendar = _calendarRepository.ListCalendars(companyName);

            return calendar.ToList();
        }

        //Actualizar un calendario existente
        public void UpdateCalendar(Calendar calendar)
        {
            _calendarRepository.Update(calendar);
        }
    }
}
