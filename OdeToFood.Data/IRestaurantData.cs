using System;
using System.Collections.Generic;
using System.Text;

using OdeToFood.Core.Models;

namespace OdeToFood.Data {
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetAll();

        Restaurant GetById(int id);

        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);

        //New Methods added to interface
        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Add(Restaurant newRestaurant);

        int Commit();
    }
}