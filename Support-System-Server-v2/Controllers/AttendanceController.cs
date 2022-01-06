using DataAccess.Model;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

//Endpoints de Asistencia

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

        //Get/Obtencion de asistencias
        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Attendance>> Get()
        {
            return Ok(_attendanceService.ListAttendances());
        }

        //Get/Obtencion de asistencias por nombre corto de la grupo empresa
        [HttpGet]
        [Route("find-by-company/{shortName}")]
        public ActionResult<ICollection<Attendance>> GetByCompany(string shortName)
        {
            return Ok(_attendanceService.ListAttendancesByCompany(shortName));
        }

        //Get/Obtencion de la nota de asistencia por nombre corto de la grupo empresa
        [HttpGet]
        [Route("grade-by-company/{shortName}")]
        public ActionResult<ICollection<GradeAverageVM>> GetGradeByCompany(string shortName)
        {
            return Ok(_attendanceService.ListGradesByCompany(shortName));
        }

        //Get/Obtencion Asistencia por su ID
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Attendance> GetById(int id)
        {
            var attendance = _attendanceService.GeyById(id);

            return Ok(attendance);
        }

        //Delete/Eliminar asistencia por su ID
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _attendanceService.DeleteAttendance(id);

            return Ok();
        }

        //Patch/Actualizar asistencia por su ID
        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Attendance> Update(Attendance attendance)
        {
            _attendanceService.UpdateAttendance(attendance);

            return Ok(attendance);
        }

    }
}
