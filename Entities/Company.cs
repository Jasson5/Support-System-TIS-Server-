using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Company: Entity
    {
        [Key]
        [StringLength(50)]
        public string ShortName { get; set; }

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

        /*Aniadir semestre*/
    }
}
