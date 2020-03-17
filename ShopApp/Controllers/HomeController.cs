using CarShop.Interfaces;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICars _allCars;

        public HomeController(ICars allCars)
        {
            _allCars = allCars;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                favCars = _allCars.FavoriteCars
            };
            return View(homeCars);
        }
    }
}
