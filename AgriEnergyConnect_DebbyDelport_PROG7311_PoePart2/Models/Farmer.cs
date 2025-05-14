using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models
{
    public class Farmer
    {
        public int FarmerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
