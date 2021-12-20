using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    public class MealController : Controller
    {
        private readonly ILogger<MealController> _logger;

        public MealController(ILogger<MealController> logger, DbConnection connection)
        {
            _logger = logger;
            DbConnection.Current = connection;
        }

        [HttpGet("/meals")]
        public IActionResult GetMeals(string id)
        {
            int userId = Convert.ToInt32(id);
            List<MealModel> meals = MealModel.GetMeals(userId);
            return Json(meals);
        }

        [HttpPost("/meals/delete")]
        public IActionResult DeleteMeals()
        {
            return Json(1);
        }

        [HttpPost("/meals/add")]
        public IActionResult AddMeals(string id)
        {
            int recipeId = Convert.ToInt32(id);

            return Json(1);
        }

    }

}