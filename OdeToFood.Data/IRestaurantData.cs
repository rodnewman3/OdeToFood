using System;
using System.Collections.Generic;
using System.Text;

using OdeToFood.Core.Models;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);
    }
}
