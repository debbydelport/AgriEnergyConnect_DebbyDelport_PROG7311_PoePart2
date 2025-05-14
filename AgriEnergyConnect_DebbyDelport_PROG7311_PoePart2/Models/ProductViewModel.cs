using System;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Display(Name = "Production Date")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        // FarmerID 
        public string FarmerID { get; set; }
    }
}
