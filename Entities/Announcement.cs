using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Announcement : Entity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAnnouncement { get; set; }

        [Required]
        [StringLength(500)]
        public string DescriptionAnnouncement { get; set; }

        [Required]
        [StringLength(1000)]
        public string DocumentAnnouncement { get; set; }
    }
}
