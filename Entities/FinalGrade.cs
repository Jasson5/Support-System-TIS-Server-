using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class FinalGrade : Entity
    {
        public int Grade { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
