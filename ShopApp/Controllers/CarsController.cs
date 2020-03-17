using Microsoft.AspNetCore.Mvc;
using CarShop.Interfaces;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICars _allCars;
        private readonly ICategory _carCategory;

        public CarsController(ICars allCars, ICategory carCategory)
        {
            _allCars = allCars;
            _carCategory = carCategory;
        }

        public ViewResult CarsList()
        {
            CarsListViewModel cars = new CarsListViewModel
            {
                AllCarsList = _allCars.Cars,
                CurrCategory = "All Type Cars"
            };
            return View(cars);
        }
    }
}
