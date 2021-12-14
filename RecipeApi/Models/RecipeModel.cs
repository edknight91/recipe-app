using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class RecipeModel
    {
        public int recipeId { get; set; }

        public string title { get; set; }

        public string method { get; set; }

        public static List<RecipeModel> GetAll()
        {
<<<<<<< HEAD
            DataTable data = DbConnection.Current.GetAllRecipes();

            List<RecipeModel> models = new List<RecipeModel>();

            foreach (DataRow r in data.Rows)
=======
            DataTable data = DbConnection.Current.GetAllProducts();

            List<RecipeModel> models = new List<RecipeModel>();

            foreach(DataRow r in data.Rows)
>>>>>>> 36b0079e65f263d51c966420d49821a817d5b647
            {
                models.Add(new RecipeModel
                {
                    recipeId = Convert.ToInt32(r["recipe_id"]),
                    title = Convert.ToString(r["title"]),
                    method = Convert.ToString(r["method"])
                });
            }

            return models;
        }
    }
}
