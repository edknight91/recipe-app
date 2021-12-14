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
            return Json(1);
        }

        [HttpGet("/recipes/{id}")]
        public IActionResult Get(string id)
        {
            return Json(1);
        }
          
        [HttpGet]
          public IActionResult GetRecipeById(string id) 
        {
            RecipeModel model = RecipeModel.Get(Convert.ToInt32(id));

            return Json(model);
        }   
    }    
 }    
