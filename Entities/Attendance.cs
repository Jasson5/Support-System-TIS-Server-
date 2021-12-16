using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Attendance : Entity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public int AttendanceStatus { get; set; }

        public int AttendanceGrade { get; set; }

        [Required]
        public User User { get; set;  }

        public string CompanyName { get; set; }

    }
}