using Microsoft.AspNetCore.Mvc;
using CarShop.Interfaces;
using CarShop.ViewModels;
using System.Collections;
using CarShop.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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

        [Route("Cars/CarsList")]
        [Route("Cars/CarsList/{category}")]
        public ViewResult CarsList(string category)
        {
            IEnumerable<Car> cars = null;
            string curCat = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(c => c.Id);
            }
            else if (string.Equals("electric", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Electric Cars")).OrderBy(c => c.Id);
                curCat = "Electric";
            }
            else if (string.Equals("classic", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Classic Cars")).OrderBy(c => c.Id);
                curCat = "Classic";
            }
            else
            {
                cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Sport Cars")).OrderBy(c => c.Id);
                curCat = "Sport";
            }


            CarsListViewModel carObj = new CarsListViewModel
            {
                AllCarsList = cars,
                CurrCategory = curCat
            };

            return View(carObj);
        }
    }
}
