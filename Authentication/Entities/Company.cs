using Authentication.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Entities
{
    //Entidad Company de la base de datos 
    public class Company 
    {
        //clave primaria de de Company es el nombre corto (ShortName) de la compania
        [Key]
        [StringLength(50)]
        public string ShortName { get; set; }  

        public int Id { get; set; }

        public DateTime? DateCreation { get; set; }

        [Required]
        [StringLength(100)]
        public string LongName { get; set; }

        [Required]
        [StringLength(5)]
        public string Society { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int Telephone { get; set; }

        [EmailAddress]
        public string CmpanyEmail { get; set; }

        [Required]
        public int CmpanyStatus { get; set; }

        //Miembros pertenecientas a la compañia
        [NotMapped]
        public ICollection<User> Members { get; set;}

        public Semester Semester { get; set; }
    }
}
