using CarShop.Interfaces;
using CarShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.DbRepo.Repositories
{
    public class CarRepo : ICars
    {
        private readonly AppDbContext _dbContext;

        public CarRepo(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public IEnumerable<Car> Cars => 
            _dbContext.Cars.Include(c => c.Category);

        public IEnumerable<Car> FavoriteCars => 
            _dbContext.Cars.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car GetCar(int carId) =>
            _dbContext.Cars.FirstOrDefault(p => p.Id == carId);
    }
}
