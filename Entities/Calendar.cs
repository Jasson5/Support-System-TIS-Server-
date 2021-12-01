using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Calendar : Entity
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DayDate { get; set; }

        [Required]
        public string DayDescription { get; set; }

        [Required]
        public string DayObsevation { get; set; }

    }

}
