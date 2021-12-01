using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Offer : Entity
    {
        [Required]
        [StringLength(50)]
        public string TitleOffer { get; set; }

        [Required]
        [StringLength(500)]
        public string DescriptionOffer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEndOffer { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public string DocuementOffer { get; set; }

        [Required]
        public int minUsers { get; set; }

        [Required]
        public int maxUsers { get; set; }
    }
}
