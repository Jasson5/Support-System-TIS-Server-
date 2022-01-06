using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.Entities
{
    //Tabla intermedia entre User y Semester de la base de datos, esto porque en caso de reprobacion un usuerio deberia poder inscribirse el siguienet semestre
    public class UserSemesters
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string SemesterCode { get; set; }
    }
}
