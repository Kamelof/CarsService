using CarsBuisnessLayer.DTOs;
using CarsCore.Models;
using CarsDataLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsBuisnessLayer
{
    public class CarsService
    {
        public static CarsRepository _carsRepository;

        static CarsService()
        {
            _carsRepository = new CarsRepository();
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            await Task.CompletedTask;

            return _carsRepository.GetAll();
        }

        public async Task<Car> GetCarById(Guid id)
        {
            await Task.CompletedTask;

            return _carsRepository.GetById(id);
        }

        public async Task<Car> DeleteCarById(Guid id)
        {
            await Task.CompletedTask;

            return _carsRepository.DeleteById(id);
        }

        public async Task<Guid> CreateCar(CarDTO carDTO)
        {
            await Task.CompletedTask;
            if(Enum.TryParse(typeof(Color), carDTO.Color, out var color) && Enum.TryParse(typeof(Carcase), carDTO.Carcase, out var carcase))
            {
                Car car = new Car
                {
                    Color = (Color)color,
                    Carcase = (Carcase)carcase,
                    ReleasDate = carDTO.ReleasDate,
                    Title = carDTO.Title,
                    weight = carDTO.Weight,
                    Price = carDTO.Price
                };

                return _carsRepository.Create(car);
            }

            return Guid.Empty;
        }

        public async Task<Car> UpdateCar(Guid id, CarDTO carDTO)
        {
            await Task.CompletedTask;
            if (Enum.TryParse(typeof(Color), carDTO.Color, out var color) && Enum.TryParse(typeof(Carcase), carDTO.Carcase, out var carcase))
            {
                Car car = new Car
                {
                    Id = id,
                    Color = (Color)color,
                    Carcase = (Carcase)carcase,
                    ReleasDate = carDTO.ReleasDate,
                    Title = carDTO.Title,
                    weight = carDTO.Weight,
                    Price = carDTO.Price
                };

                return _carsRepository.Update(car);
            }

            return null;
        }
    }
}