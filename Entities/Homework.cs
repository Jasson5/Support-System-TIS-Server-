using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;

//Entidad Tarea con atributos Titulo, DescripcionDeLaTarea, Link del repositorio donde se almacenara los archivos, FechaDeEntrega,
//Estado de la tarea, Nota de la Tarea, Grupo Empresa a la que se asigno la tarea.

namespace Entities
{
    public class Homework : Entity
    {
        [Required]
        [StringLength(50)]
        public string Tittle { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public string HomeworkFileLink { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        public int HomeworkStatus { get; set; }

        public int Grade { get; set; }

        [Required]
        public Company Company { get; set; }
    }
}
