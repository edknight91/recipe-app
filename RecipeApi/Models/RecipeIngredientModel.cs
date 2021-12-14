using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class RecipeIngredientModel
    {
        public int recipeIngredientId { get; set; }
        public int recipeId { get; set; }
        public int ingredientId { get; set; }
        public int quantity { get; set; }

        public static List<RecipeIngredientModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllRecipeIngredients();

            List<RecipeIngredientModel> models = new List<RecipeIngredientModel>();

            foreach(DataRow r in data.Rows)
            {
                models.Add(new RecipeIngredientModel
                {
                    recipeIngredientId = Convert.ToInt32(r["recipe_ingredient_id"]),
                    recipeId = Convert.ToInt32(r["recipe_id"]),
                    ingredientId = Convert.ToInt32(r["ingredient_id"]),
                    quantity = Convert.ToInt32(r["quantity"])
                });
            }

            return models;
        }
    }
}
