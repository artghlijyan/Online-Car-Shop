using CarShop.DbRepo;
using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Interfaces
{
    public interface ICars
    {
        IEnumerable<Car> Cars { get; }

        IEnumerable<Car> FavoriteCars { get; }

        Car GetCar(int carId);
    }
}
