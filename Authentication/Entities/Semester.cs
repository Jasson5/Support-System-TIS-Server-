using System;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Entities
{
    //Entidad Semestre de la base de datos, hará que se pueda tener espacios separados
    public class Semester 
    {
        public DateTime? DateCreation { get; set; }

        [Required]
        public string Name { get; set; }

        //codigo alfanumerico que los Estudiantes usarán luego para poder inscribirse en el semestre
        [Key]
        [Required]
        public string Code { get; set; }

        public int StatusId { get; set; }
    }

}
