using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

//Endpoints de Calendario

namespace Support_System_Server_v2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            this._calendarService = calendarService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Calendar> Post(Calendar calendar)
        {
            calendar.DateCreation = TimeZoneHelper.GetSaWesternStandardTime();
            return _calendarService.AddCalendar(calendar);
        }

        //Get/Obtener Calendario(Observaciones) por empresa y fecha
        [HttpGet]
        [Route("{companyName}/{date}")]
        public ActionResult<Calendar> GetById(string companyName, DateTime date)
        {
            var calendar = _calendarService.GeyById(companyName, date);

            return Ok(calendar);
        }

        //Get/Obtener Calendario(Observaciones) por empresa
        [HttpGet]
        [Route("{companyName}")]
        public ActionResult<Calendar> GetById(string companyName)
        {
            var calendar = _calendarService.ListCalendars(companyName);

            return Ok(calendar);
        }

        //Delete/Eliminar por su ID
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _calendarService.DeleteCalendar(id);

            return Ok();
        }

        //Patch/Actualizar por su ID
        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Calendar> Update(Calendar calendar)
        {
            _calendarService.UpdateCalendar(calendar);

            return Ok(calendar);
        }

    }
}
