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
        private readonly AppDbContext appDbContext;

        public CarRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Car> Cars => 
            appDbContext.Car.Include(c => c.Category);

        public IEnumerable<Car> FavoriteCars => 
            appDbContext.Car.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car GetCar(int carId) =>
            appDbContext.Car.FirstOrDefault(p => p.Id == carId);
    }
}
