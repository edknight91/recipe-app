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

        public List<IngredientModel> Ingredients { get; set; }

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

        public static List<IngredientModel> GetIngredients(int recipeId)
        {
            DataTable data = DbConnection.Current.GetIngredientByRecipeId(recipeId);

            List<IngredientModel> models = new List<IngredientModel>();

            foreach (DataRow i in data.Rows)
            {
                models.Add(new IngredientModel
                {
                    ingredientId = Convert.ToInt32(i["ingredient_id"]),
                    title = Convert.ToString(i["title"])
                });

                // TODO: For now, load the recipe ingredient list here and add to each model
            }

            return models;
        }

        public static RecipeModel Get(int id)
        {
            // List<RecipeModel> allRecipe = new List<RecipeModel>(GetAll());
            DataTable table = DbConnection.Current.GetRecipeById(id);

            if (table == null || table.Rows.Count == 0) return null;

            DataRow row = table.Rows[0];

            int recipeId = Convert.ToInt32(row["recipe_id"]);

            RecipeModel recipe = new RecipeModel
            {
                recipeId = recipeId,
                title = Convert.ToString(row["title"]),
                method = Convert.ToString(row["method"]),
                Ingredients = IngredientModel.GetForRecipe(recipeId)
            };

            return recipe;

            // foreach (RecipeModel r in allRecipe)
            // {
            //     if (r.recipeId == id)
            //         return r;
            // }

            // DataTable ingredients = DbConnection.Current.GetIngredientByRecipeId(id);

            // foreach (DataRow i in ingredients.Rows)
            // {
            //     ingredients.Add(new RecipeModel()
            //     {
            //         ingredientId = Convert.ToInt32(i["ingredient_id"]),
            //         title = Convert.ToString(i["title"])
            //     });

            //     // TODO: For now, load the recipe ingredient list here and add to each model
            // }

            // return models;

            // return null;
        }
    }
}
