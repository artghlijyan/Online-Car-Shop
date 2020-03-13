using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
