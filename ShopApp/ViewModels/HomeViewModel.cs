using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavCars { get; set; }
    }
}
