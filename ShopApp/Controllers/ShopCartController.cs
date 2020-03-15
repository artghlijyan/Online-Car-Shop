using Microsoft.AspNetCore.Mvc;
using CarShop.Models;
using CarShop.ViewModels;
using System.Linq;
using CarShop.Interfaces;

namespace CarShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICars _carRepo;
        private readonly ShopCart _shopCart;

        public ShopCartController(ICars carRepo, ShopCart shopCart)
        {
            _carRepo = carRepo;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel()
            {
                ShopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRepo.Cars.FirstOrDefault(c => c.Id == id);
            
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
