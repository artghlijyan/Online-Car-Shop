using CarShop.Interfaces;
using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Mocks
{
    public class MockCategory : ICarCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category
                    {
                        categoryName = "Electric Cars",
                        description = "Cars On Elektrik Engine"
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
            }
        }
    }
}
