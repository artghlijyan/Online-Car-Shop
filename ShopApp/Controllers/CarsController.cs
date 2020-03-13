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

        public ViewResult AllCars()
        {
            AllCarsViewModel obj = new AllCarsViewModel();
            obj.AllCars = _allCars.Cars;
            obj.CurrCategory = "All Type Cars";
            return View(obj);
        }
    }
}
