using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Calendar : Entity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DayDate { get; set; }

        [Required]
        public string DayDescription { get; set; }

        [Required]
        public string DayObservation { get; set; }

        public Company Company { get; set; }

    }

}
