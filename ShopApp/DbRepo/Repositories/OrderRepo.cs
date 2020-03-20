using CarShop.Interfaces;
using CarShop.Models;
using System;

namespace CarShop.DbRepo.Repositories 
{
    public class OrderRepo : IAllOrders
    {
        private readonly AppDbContext _dbContext;
        private readonly ShopCart _shopCart;

        public OrderRepo(AppDbContext dbContext, ShopCart shopCart)
        {
            _dbContext = dbContext;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _dbContext.Orders.Add(order); 

            var items = _shopCart.ListShopItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };

                _dbContext.Add(orderDetail);
            }

            _dbContext.SaveChanges();   
        }
    }
}
