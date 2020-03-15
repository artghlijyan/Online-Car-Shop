using CarShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.DbRepo
{
    public class DbObjects
    {
        private static Dictionary<string, Category> categories;

        public static void Initialize(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Cars.Any())
            {
                context.AddRange(
                new Car
                {
                    Name = "Tesla Model S",
                    Image = "/img/teslas.jpg",
                    Price = 45000,
                    IsFavorite = true,
                    IsAvailable = true,
                    Category = Categories["Electric Cars"]
                },

                new Car
                {
                    Name = "Nissan SkyLine r34",
                    Image = "/img/nissanr34.jpg",
                    Price = 120000,
                    IsFavorite = true,
                    IsAvailable = true,
                    Category = Categories["Sport Cars"]
                },

                new Car
                {
                    Name = "Mini Cooper",
                    Image = "/img/mrbean.jpg",
                    Price = 28000,
                    IsFavorite = true,
                    IsAvailable = true,
                    Category = Categories["Classic Cars"]
                });
            }

            context.SaveChanges();
        }

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories is null)
                {
                    var list = new Category[]
                    {
                    new Category
                    {
                        categoryName = "Electric Cars",
                        description = "Cars On Elektric Engine"
                    },

                    new Category
                    {
                        categoryName = "Classic Cars",
                        description = "Cars On Fuel Engine"
                    },

                    new Category
                    {
                        categoryName = "Sport Cars",
                        description = "Sport Cars"
                    }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (var item in list)
                    {
                        categories.Add(item.categoryName, item);
                    }
                }

                return categories;
            }
        }
    }
}
