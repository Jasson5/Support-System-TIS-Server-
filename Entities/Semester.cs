using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Semester : Entity
    {
        [Required]
        [StringLength(7)]
        public string NameSemester { get; set; }

        [Required]
        [StringLength(7)]
        public string CodeSemester { get; set; }

    }

}
