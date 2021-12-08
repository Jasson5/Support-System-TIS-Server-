using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.Entities
{
    public class UserSemesters
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Semester Semester { get; set; }
    }
}
