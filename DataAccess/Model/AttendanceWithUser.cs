using System;

namespace DataAccess.Model
{
    public class AttendanceWithUser
    {
        //Clase de apoyo 
        public int Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int AttendanceStatus { get; set; }
        public int AttendanceGrade { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public string GivenName { get; set; }
    }
}
