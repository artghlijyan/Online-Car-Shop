using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Interfaces
{
    public interface ICarCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
