using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCarsList { get; set; }

        public string CurrCategory { get; set; }
    }
}
