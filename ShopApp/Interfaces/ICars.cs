using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Interfaces
{
    public interface ICars
    {
        IEnumerable<Car> Cars { get; }

        IEnumerable<Car> FavoriteCars { get; set; }

        Car GetCar(int carId);
    }
}
