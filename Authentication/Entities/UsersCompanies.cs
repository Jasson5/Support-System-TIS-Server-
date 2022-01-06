using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.Entities
{
    ////Tabla intermedia entre User y Company de la base de datos, esto porque un usario puede repetir la materia y debe estar en otra compañia para eso
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
