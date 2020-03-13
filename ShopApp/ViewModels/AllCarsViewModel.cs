using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.ViewModels
{
    public class AllCarsViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }

        public string CurrCategory { get; set; }
    }
}
