using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarsCore.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public int ReleasDate { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        [Column("ColorId")]
        [JsonIgnore]
        public Color Color { get; set; }
        public int Weight { get; set; }
        [Column("CarBodyId")]
        [JsonIgnore]
        public CarBody CarBody { get; set; }
    }
}