using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;

//Entidad de Anuncio modelada con sus atributos: Descripción, URL del Documento, Semestre.

namespace Entities
{
    public class Announcement : Entity
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public string DocumentUrl { get; set; }

        [Required]
        public Semester Semester { get; set; }
    }
}
