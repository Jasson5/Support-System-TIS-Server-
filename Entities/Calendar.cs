using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;


//Entidad Calendario(Donde se guardan las anotaciones de la clase), con los atributos DiaDeLaClase, DescripcionDelDia,
//ObservacionesParaLaSiguiente, GrupoEmpresa.

namespace Entities
{
    public class Calendar : Entity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DayDate { get; set; }

        [Required]
        public string DayDescription { get; set; }

        [Required]
        public string DayObservation { get; set; }

        [Required]
        public string CompanyName { get; set; }

    }

}
