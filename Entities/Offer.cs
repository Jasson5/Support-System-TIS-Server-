using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Offer : Entity
    {
        [Required]
        public Authentication.Entities.User User { get; set; }

        [Required]
        [StringLength(50)]
        public string TitleOffer { get; set; }

        [Required]
        [StringLength(500)]
        public string DescriptionOffer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEndOffer { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        [StringLength(1000)]
        public string DocuementOffer { get; set; }

        [Required]
        public int minUsers { get; set; }

        [Required]
        public int maxUsers { get; set; }
    }
}
