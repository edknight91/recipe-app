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

        // TODO: List of ingredients here

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

                // TODO: For now, load the recipe ingredient list here and add to each model
            }

            return models;
        }

        public static RecipeModel Get(int id)
        {
            List<RecipeModel> allRecipe = new List<RecipeModel>(GetAll());

            foreach (RecipeModel r in allRecipe)
            {
                if (r.recipeId == id)
                    return r;
            }
            return null;
        }
    }
}
