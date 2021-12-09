using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Support_System_Server_v2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            this._attendanceService = attendanceService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Attendance> Post(Attendance attendance)
        {
            attendance.DateCreation = TimeZoneHelper.GetSaWesternStandardTime();
            return _attendanceService.AddAttendance(attendance);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Attendance>> Get()
        {
            return Ok(_attendanceService.ListAttendances());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Attendance> GetById(int id)
        {
            var attendance = _attendanceService.GeyById(id);

            return Ok(attendance);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _attendanceService.DeleteAttendance(id);

            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Attendance> Update(Attendance attendance)
        {
            _attendanceService.UpdateAttendance(attendance);

            return Ok(attendance);
        }

    }
}
