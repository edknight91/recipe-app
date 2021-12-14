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
            DataTable data = DbConnection.Current.GetAllRecipes();

            List<RecipeModel> models = new List<RecipeModel>();

            foreach (DataRow r in data.Rows)
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
