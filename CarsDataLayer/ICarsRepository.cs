using CarsCore.Models;
using System;
using System.Collections.Generic;

namespace CarsDataLayer
{
    public interface ICarsRepository
    {
        Guid Create(Car car);
        Car DeleteById(Guid id);
        List<Car> GetAll();
        Car GetById(Guid id);
        Car Update(Car car);
    }
}