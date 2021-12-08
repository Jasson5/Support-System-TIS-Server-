using System;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Entities
{
    public class Semester 
    {
        public DateTime? DateCreation { get; set; }

        [Required]
        public string Name { get; set; }

        [Key]
        [Required]
        public string Code { get; set; }

        public int StatusId { get; set; }
    }

}
