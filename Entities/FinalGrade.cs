using System;
using System.Collections.Generic;
using System.Text;

//Entidad NotaFinal con los atributos de NotaFinal, Usuario y GrupoEmpresa.

namespace Entities
{
    public class FinalGrade : Entity
    {
        public int Grade { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
