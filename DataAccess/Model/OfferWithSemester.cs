using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class OfferWithSemester
    {
        public int id { get; set; }

        public DateTime DateCreation { get; set; }

        public string Description { get; set; }

        public DateTime DateEnd { get; set; }

        public string DocumentOfferUrl { get; set; }

        public int MinUsers { get; set; }

        public int MaxUsers { get; set; }

        public string SemesterCode { get; set; }
    }
}
