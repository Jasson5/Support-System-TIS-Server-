using System;

//Entidad de la que heredan algunas otras entidades para tener un ID y su FechaDeCreación.

namespace Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime DateCreation { get; set; }

    }
}
