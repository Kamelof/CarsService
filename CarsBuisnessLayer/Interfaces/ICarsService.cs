using CarsBuisnessLayer.DTOs;
using CarsCore.Models.CarModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Interfaces
{
    public interface ICarsService
    {
        Task<Guid> CreateCar(CarDTO carDTO);
        Task<Car> DeleteCarById(Guid id);
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(Guid id);
        Task<Car> UpdateCar(Guid id, CarDTO carDTO);
    }
}