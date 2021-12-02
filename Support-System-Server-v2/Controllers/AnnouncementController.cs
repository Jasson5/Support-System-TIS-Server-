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
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            this._announcementService = announcementService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Announcement> Post(Announcement announcement)
        {
            return _announcementService.AddAnnouncement(announcement);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Announcement>> Get()
        {
            return Ok(_announcementService.ListAnnouncements());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Announcement> GetById(int id)
        {
            var announcement = _announcementService.GeyById(id);

            return Ok(announcement);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _announcementService.DeleteAnnouncement(id);

            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Announcement> Update(Announcement announcement)
        {
            _announcementService.UpdateAnnouncement(announcement);

            return Ok(announcement);
        }
    }
}
