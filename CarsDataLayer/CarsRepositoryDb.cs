﻿using CarsCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDataLayer
{
    public class CarsRepositoryDb : ICarsRepository
    {
        private readonly EFCoreContext _dbContext;

        public CarsRepositoryDb(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Create(Car car)
        {
            car.Id = Guid.NewGuid();
            var dbColor = _dbContext.Colors.Where(x => x.Title == car.Color.ToString());
            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();

            return car.Id;
        }

        public async Task<Car> DeleteById(Guid id)
        {
            Car entity = await GetById(id);
            if(entity != null)
            {
                _dbContext.Cars.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<List<Car>> GetAll() => await _dbContext.Cars.ToListAsync();

        public async Task<Car> GetById(Guid id) =>
            await _dbContext.Cars.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Car> Update(Car car)
        {
            _dbContext.Attach(car);
            _dbContext.Entry(car).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return car;
        }
    }
}
