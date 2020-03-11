using Microsoft.AspNetCore.Mvc;
using CarShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICars _allCars;
        private readonly ICarCategory _carCategory;

        public CarsController(ICars allCars, ICarCategory carCategory)
        {
            _allCars = allCars;
            _carCategory = carCategory;
        }

        public ViewResult AllCars()
        {
            var cars = _allCars.Cars;
            return View(cars);
        }
    }
}
