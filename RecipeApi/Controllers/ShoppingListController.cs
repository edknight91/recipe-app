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
    public class ShoppingListController : Controller
    {
        private readonly ILogger<ShoppingListController> _logger;

        public ShoppingListController(ILogger<ShoppingListController> logger, DbConnection connection)
        {
            _logger = logger;
            DbConnection.Current = connection;
        }

        [HttpGet("/shoppinglist")]
        public IActionResult Index()
        {
            return Json(1);
        }

    }
}