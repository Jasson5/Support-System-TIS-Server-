using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;

//Entidad Convocatoria con los atributos Descripción, FechaPlazo de la convocatoria, Semestre, Link del repositorio donde se almacenaran
// los documentos publicados de convocatoria, Minimo y Maximo de usuarios que permitira en una GrupoEmpresa para esa Convocatoria.

namespace Entities
{
    public class Offer : Entity
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public string DocumentOfferUrl { get; set; }

        [Required]
        public int MinUsers { get; set; }

        [Required]
        public int MaxUsers { get; set; }
    }
}
