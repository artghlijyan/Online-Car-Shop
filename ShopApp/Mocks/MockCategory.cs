using CarShop.Interfaces;
using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Mocks
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category
                    {
                        CategoryName = "Electric Cars",
                        Description = "Cars On Elektrik Engine"
                    },

                    new Category
                    {
                        CategoryName = "Classic Cars",
                        Description = "Cars On Fuel Engine"
                    },

                    new Category
                    {
                        CategoryName = "Sport Cars",
                        Description = "Sport Cars"
                    }
                };
            }
        }
    }
}
