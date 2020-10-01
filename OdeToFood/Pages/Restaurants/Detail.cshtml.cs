using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OdeToFood.Core.Enums;
using OdeToFood.Core.Models;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants {
    public class DetailModel : PageModel {
        public Restaurant Restaurant { get; set; }

        private readonly IRestaurantData restaurantData;

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId) {
            Restaurant = restaurantData.GetById(restaurantId);
            return Restaurant == null 
                ? (IActionResult)RedirectToPage("./NotFound") 
                : Page();

            // the ternary statement above is the same as this if/else:
            // if (Restaurant == null) {
            //    return RedirectToPage("./NotFound");
            //}
            // return Page();
        }
    }
}