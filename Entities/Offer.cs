using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Offer : Entity
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

       // [Required]
        public Semester Semester { get; set; }

        [Required]
        public string DocumentOfferUrl { get; set; }

        [Required]
        public int MinUsers { get; set; }

        [Required]
        public int MaxUsers { get; set; }
    }
}
