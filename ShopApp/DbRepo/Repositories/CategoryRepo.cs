using CarShop.Interfaces;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.DbRepo.Repositories
{
    public class CategoryRepo : ICategory
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => appDbContext.Category;
    }
}
