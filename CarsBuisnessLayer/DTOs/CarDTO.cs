using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.DTOs
{
    public class CarDTO
    {
        public int ReleasDate { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public string Carcase { get; set; }
    }
}
