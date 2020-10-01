using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using OdeToFood.Core.Enums;
using OdeToFood.Core.Models;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants {
    public class EditModel : PageModel {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId) {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = restaurantId.HasValue 
                ? restaurantData.GetById(restaurantId.Value) 
                : new Restaurant();

            return Restaurant == null 
                ? (IActionResult)RedirectToPage("./NotFound") 
                : Page();

            // the ternary statement above is the same as this if/else:
            // if (Restaurant == null) {
            //    return RedirectToPage("./NotFound");
            //}
            // return Page();
        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid) {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0) {
                restaurantData.Update(Restaurant);
            }
            else {
                restaurantData.Add(Restaurant);
            }
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}