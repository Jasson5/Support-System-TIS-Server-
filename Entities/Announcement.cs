using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Announcement : Entity
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string DocumentUrl { get; set; }
    }
}
