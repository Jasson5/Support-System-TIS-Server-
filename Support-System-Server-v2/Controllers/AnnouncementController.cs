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
            announcement.DateCreation = TimeZoneHelper.GetSaWesternStandardTime();
            return _announcementService.AddAnnouncement(announcement);
        }

        [HttpGet]
        [Route("{code}")]
        public ActionResult<ICollection<Announcement>> Get(string code)
        {
            return Ok(_announcementService.ListAnnouncements(code));
        }

        [HttpGet]
        [Route("find-by-id/{id}")]
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
