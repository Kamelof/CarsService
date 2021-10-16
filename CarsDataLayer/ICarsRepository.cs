using CarsCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsDataLayer
{
    public interface ICarsRepository
    {
        Task<Guid> Create(Car car);
        Task<Car> DeleteById(Guid id);
        Task<List<Car>> GetAll();
        Task<Car> GetById(Guid id);
        Task<Car> Update(Car car);
    }
}