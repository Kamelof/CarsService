using AutoMapper;
using CarsBuisnessLayer.DTOs;
using CarsCore.Models;
using CarsDataLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsBuisnessLayer
{
    public class CarsService : ICarsService
    {
        public readonly ICarsRepository _carsRepository;
        private readonly IMapper _mapper;

        public CarsService(ICarsRepository carsRepository, IMapper mapper)
        {
            _carsRepository = carsRepository;
            _mapper = mapper;
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

            Car car = _mapper.Map<Car>(carDTO);
            if (car != null)
            {
                return _carsRepository.Create(car);
            }

            return Guid.Empty;
        }

        public async Task<Car> UpdateCar(Guid id, CarDTO carDTO)
        {
            await Task.CompletedTask;

            Car car = _mapper.Map<Car>(carDTO);
            if (car != null)
            {
                car.Id = id;
                return _carsRepository.Update(car);
            }

            return null;
        }
    }
}