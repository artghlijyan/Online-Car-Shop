using CarShop.Interfaces;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Mocks
{
    public class MockCars : ICars
    {
        private readonly ICategory _carCategory = new MockCategory();

        public IEnumerable<Car> FavoriteCars { get; set; }

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Tesla Model S",
                        Image = "/img/teslas.jpg",
                        Price = 45000,
                        IsFavorite = false,
                        IsAvailable = true,
                        Category = _carCategory.AllCategories.Single(p => p.categoryName == "Electric Cars")
                    },
                
                    new Car
                    {
                        Name = "Nissan SkyLine r34",
                        Image = "/img/nissanr34.jpg",
                        Price = 120000,
                        IsFavorite = true,
                        IsAvailable = true,
                        Category = _carCategory.AllCategories.Single(p => p.categoryName == "Sport Cars")
                    },

                    new Car
                    {
                        Name = "Mini Cooper",
                        Image = "/img/mrbean.jpg",
                        Price = 28000,
                        IsFavorite = false,
                        IsAvailable = true,
                        Category = _carCategory.AllCategories.Single(p => p.categoryName == "Classic Cars")
                    }
                };
            }
        }

        public Car GetCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
