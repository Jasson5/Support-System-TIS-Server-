using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Semester : Entity
    {
        [Required]
        [StringLength(7)]
        public string Name { get; set; }

        [Required]
        [StringLength(7)]
        public string Code { get; set; }

    }

}
