using Authentication.Entities;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Endpoints de semestre

namespace Support_System_Server_v2.Controllers
{
    [Authorize]
    [Route("api/semester")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            this._semesterService = semesterService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Semester> Post(Semester semester)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }

            semester.DateCreation = TimeZoneHelper.GetSaWesternStandardTime();
            var newSemester = _semesterService.AddSemester(semester);

            return Created("api/semesters", newSemester);
        }

        //Get/Obtener semestres
        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Semester>> Get()
        {
            return Ok(_semesterService.ListSemesters());
        }

        //Get/Obtener semestre por su codigo
        [HttpGet]
        [Route("{code}")]
        public ActionResult<Semester> GetByCode(string code)
        {
            var semester = _semesterService.FindByCode(code);

            return Ok(semester);
        }

        //Get/Obtener usuario especifico en semestres
        [HttpGet]
        [Route("list-by-user/{userId}")]
        public ActionResult<Semester> GetByUserId(int userId)
        {
            var semester = _semesterService.ListByUserId(userId);

            return Ok(semester);
        }

        //Get/Obtener lista de usuarios por semestre
        [HttpGet]
        [Route("list-users-by-semester")]
        public ActionResult<Semester> LisUsersBySemester([FromQuery] UsersRequestParameters query)
        {
            var semester = _semesterService.ListUsersBySemester(query);

            return Ok(semester);
        }

        //Get/Obtener para que un usuario ingrese al semestre por su respectivo codigo
        [HttpGet]
        [Route("join-to-semester/{userId}/{semesterCode}")]
        public async Task<ActionResult> JoinToSemester(int userId, string semesterCode)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }

            _semesterService.AddUserToSemester(userId, semesterCode);

            return Ok();
        }
    }

}
