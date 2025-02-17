using Microsoft.AspNetCore.Mvc;
using MyFoodMvcApp.Models;

namespace MyFoodMvcApp.Controllers
{
    public class TestController : Controller
    {
        // This will store the collection of foods
        private static List<Food> foods = new List<Food>
        {
            new Food { Name = "Pizza", Halal = true },
            new Food { Name = "Burger", Halal = false },
            new Food { Name = "Sushi", Halal = true },
            new Food { Name = "Hot Dog", Halal = false },
            new Food { Name = "Pork", Halal = false },
            new Food { Name = "Falafel", Halal = true }
        };

        // Action to return all halal foods in JSON format
        public IActionResult GetAll()
        {
            var halalFoods = foods.Where(f => f.Halal).ToList();
            return Json(halalFoods);  // Return as JSON
        }
    }
}
