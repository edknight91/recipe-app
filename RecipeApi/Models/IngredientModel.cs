using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class IngredientModel
    {
        public int ingredientId { get; set; }
        public string title { get; set; }
        public bool wet { get; set; }
        public bool algnCelery { get; set; }
        public bool algnGluten { get; set; }
        public bool algnCrust { get; set; }
        public bool algnEggs { get; set; }
        public bool algnFish { get; set; }
        public bool algnLupin { get; set; }
        public bool algnMilk { get; set; }
        public bool algnMollusc { get; set; }
        public bool algnMustard { get; set; }
        public bool algnPeanut { get; set; }
        public bool algnSesame { get; set; }
        public bool algnSoya { get; set; }
        public bool algnSulphite { get; set; }
        public bool algnTreenut { get; set; }
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public int Quantity { get; set; }

        public static List<IngredientModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllIngredients();

            return IngredientModel.FromDataTable(data);
        }

        public static List<IngredientModel> GetForRecipe(int recipeId)
        {
            DataTable data = DbConnection.Current.GetIngredientByRecipeId(recipeId);

            return IngredientModel.FromDataTable(data);
        }


        public static List<IngredientModel> FromDataTable(DataTable table)
        {
            List<IngredientModel> models = new List<IngredientModel>();

            foreach (DataRow r in table.Rows)
            {
                models.Add(new IngredientModel
                {
                    ingredientId = Convert.ToInt32(r["ingredient_id"]),
                    title = Convert.ToString(r["title"]),
                    wet = Convert.ToBoolean(r["wet"]),
                    algnCelery = Convert.ToBoolean(r["algn_celery"]),
                    algnGluten = Convert.ToBoolean(r["algn_gluten"]),
                    algnCrust = Convert.ToBoolean(r["algn_crust"]),
                    algnEggs = Convert.ToBoolean(r["algn_eggs"]),
                    algnFish = Convert.ToBoolean(r["algn_fish"]),
                    algnLupin = Convert.ToBoolean(r["algn_lupin"]),
                    algnMilk = Convert.ToBoolean(r["algn_milk"]),
                    algnMollusc = Convert.ToBoolean(r["algn_mollusc"]),
                    algnMustard = Convert.ToBoolean(r["algn_mustard"]),
                    algnPeanut = Convert.ToBoolean(r["algn_peanut"]),
                    algnSesame = Convert.ToBoolean(r["algn_sesame"]),
                    algnSoya = Convert.ToBoolean(r["algn_soya"]),
                    algnSulphite = Convert.ToBoolean(r["algn_sulphite"]),
                    algnTreenut = Convert.ToBoolean(r["algn_treenut"]),
                    vegetarian = Convert.ToBoolean(r["vegetarian"]),
                    vegan = Convert.ToBoolean(r["vegan"]),
                    Quantity = Convert.ToInt32(r["quantity"])
                });
            }

            return models;
        }


    }
}
