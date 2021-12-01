using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Company: Entity
    {
        [Key]
        public string ShortName { get; set; }

        public string LongName { get; set; }

        public string Society { get; set; }

        public string Address { get; set; }

        public int Telephone { get; set; }

        public string CmpanyEmail { get; set; }
    }
}
