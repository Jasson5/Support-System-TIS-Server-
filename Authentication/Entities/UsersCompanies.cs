using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.Entities
{
    public class UsersCompanies
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ShortName { get; set; }
        public string SemesterCode { get; set; }

        public string Role { get; set; }

    }
}
