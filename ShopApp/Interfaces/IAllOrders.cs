using CarShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
