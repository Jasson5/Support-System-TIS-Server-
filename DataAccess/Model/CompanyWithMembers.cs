using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class CompanyWithMembers
    {
        public int Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Society { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public string CmpanyEmail { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GivenName { get; set; }
        public string Role { get; set; }
    }
}
