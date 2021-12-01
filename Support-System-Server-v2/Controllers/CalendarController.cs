using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

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
            return _calendarService.AddCalendar(calendar);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Calendar>> Get()
        {
            return Ok(_calendarService.ListCalendars());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Calendar> GetById(int id)
        {
            var calendar = _calendarService.GeyById(id);

            return Ok(calendar);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _calendarService.DeleteCalendar(id);

            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Calendar> Update(Calendar calendar)
        {
            _calendarService.UpdateCalendar(calendar);

            return Ok(calendar);
        }

    }
}
