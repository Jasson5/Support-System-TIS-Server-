using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
