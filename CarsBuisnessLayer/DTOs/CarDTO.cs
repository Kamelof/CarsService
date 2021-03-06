using System.ComponentModel.DataAnnotations;

namespace CarsBuisnessLayer.DTOs
{
    public class CarDTO
    {
        [Required]
        public int ReleasDate { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public string CarBody { get; set; }
    }
}
