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

        public User User { get; set; }

        public Company Company { get; set; }

    }
}
