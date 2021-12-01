using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Announcement : Entity
    {
        [Required]
        public User User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAnnouncement { get; set; }

        [Required]
        [StringLength(500)]
        public string DescriptionAnnouncement { get; set; }

        [Required]
        [StringLength(1000)]
        public string DocumentAnnouncement { get; set; }
    }
}
