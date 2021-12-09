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
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkService homeworkService)
        {
            this._homeworkService = homeworkService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Homework> Post(Homework homework)
        {
            homework.DateCreation = TimeZoneHelper.GetSaWesternStandardTime();
            return _homeworkService.AddHomework(homework);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Homework>> Get()
        {
            return Ok(_homeworkService.ListHomeworks());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Homework> GetById(int id)
        {
            var homework = _homeworkService.GeyById(id);

            return Ok(homework);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _homeworkService.DeleteHomework(id);

            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Homework> Update(Homework homework)
        {
            _homeworkService.UpdateHomework(homework);

            return Ok(homework);
        }

    }
}
