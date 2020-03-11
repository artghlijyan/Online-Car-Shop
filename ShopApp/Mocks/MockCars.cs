using CarShop.Interfaces;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Mocks
{
    class MockCars : ICars
    {
        private readonly ICarCategory _carCategory = new MockCategory();

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
                        Image = "https://images.app.goo.gl/CX3KsFscjq42YjYo6",
                        Price = 45000,
                        IsFavorite = true,
                        IsAvailable = true,
                        Category = _carCategory.AllCategories.Single(p => p.categoryName == "Electric Cars")
                    },
                
                    new Car
                    {
                        Name = "Nissan SkyLine r34",
                        Image = "https://images.app.goo.gl/9Nyr8RBY2Ag88ngo8",
                        Price = 120000,
                        IsFavorite = true,
                        IsAvailable = true,
                        Category = _carCategory.AllCategories.Single(p => p.categoryName == "Sport Cars")
                    },

                    new Car
                    {
                        Name = "Mini Cooper",
                        Image = "https://images.app.goo.gl/aTP1oz6GjdrwnFdDA",
                        Price = 28000,
                        IsFavorite = true,
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
