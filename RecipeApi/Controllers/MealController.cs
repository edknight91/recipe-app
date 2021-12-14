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
        public IActionResult Index()
        {

            return Json(1);
        }
    }

}