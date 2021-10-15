using System;
using System.Collections.Generic;
using System.Linq;
using CarsCore.Models;

namespace CarsDataLayer
{
    public class CarsRepository : ICarsRepository
    {
        private static List<Car> _cars;

        static CarsRepository()
        {
            _cars = new List<Car>();
        }
        public Guid Create(Car car)
        {
            car.Id = Guid.NewGuid();
            _cars.Add(car);

            return car.Id;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(Guid id)
        {
            return _cars.FirstOrDefault(x => x.Id == id);
        }

        public Car Update(Car car)
        {
            var oldCar = _cars.FirstOrDefault(x => x.Id == car.Id);
            if (oldCar != null)
            {
                int index = _cars.IndexOf(oldCar);

                _cars[index] = car;

                return car;
            }

            return null;
        }

        public Car DeleteById(Guid id)
        {
            Car neededToDeleteCar = _cars.FirstOrDefault(x => x.Id == id);
            if (neededToDeleteCar != null)
            {
                _cars.Remove(neededToDeleteCar);
            }

            return neededToDeleteCar;
        }
    }
}