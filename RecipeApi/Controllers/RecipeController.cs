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
    public class RecipeController : Controller
    {
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(ILogger<RecipeController> logger, DbConnection connection)
        {
            _logger = logger;
            DbConnection.Current = connection;
        }

        [HttpGet("/recipes")]
        public IActionResult Search(string keyword)
        {
            List<RecipeModel> recipes = RecipeModel.GetAll();
            return Json(recipes);
        }

        [HttpGet("/recipes/{id}")]
        public IActionResult Get(string id)
        {
            int recipeId = Convert.ToInt32(id);

            RecipeModel recipe = RecipeModel.Get(recipeId);

            return Json(recipe);
        }
    }
}