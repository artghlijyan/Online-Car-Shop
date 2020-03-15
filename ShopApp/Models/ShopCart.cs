using CarShop.DbRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Models
{
    public class ShopCart
    {
        private readonly AppDbContext _dbContext;

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public ShopCart(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            this._dbContext.ShopCartItems.Add(
                new ShopCartItem
                {
                    ShopCartId = this.ShopCartId,
                    Car = car,
                    Price = car.Price,
                });

            _dbContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _dbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
