using System;

namespace CarsCore.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public int ReleasDate { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Color Color { get; set; }
        public int Weight { get; set; }
        public CarBody CarBody { get; set; }
    }
}