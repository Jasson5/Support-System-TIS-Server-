using System.ComponentModel.DataAnnotations;

namespace Authentication.Entities
{
    //Roles que puede adoptar un User, estos pueden ser Administrador y Estudiante
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}
