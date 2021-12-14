using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class IngredientModel
    {
        public int ingredientId { get; set; }
        public string title { get; set; }
        public int wet { get; set; }
        public int algnCelery { get; set; }
        public int algnGluten { get; set; }
        public int algnCrust { get; set; }
        public int algnEggs { get; set; }
        public int algnFish { get; set; }
        public int algnMilk { get; set; }
        public int algnMollusc { get; set; }
        public int algnMustard { get; set; }
        public int algnPeanut { get; set; }
        public int algnSesame { get; set; }
        public int algnSulphite { get; set; }
        public int algnTreenut { get; set; }
        public int vegetarian { get; set; }
        public int vegan { get; set; }


        public static List<IngredientModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllIngredients();

            List<IngredientModel> models = new List<IngredientModel>();

            foreach(DataRow r in data.Rows)
            {
                models.Add(new IngredientModel
                {
                    ingredientId = Convert.ToInt32(r["ingredient_id"]),
                    title = Convert.ToString(r["title"]),
                    wet = Convert.ToInt32(r["wet"]),
                    algnCelery = Convert.ToInt32(r["algn_celery"]),
                    algnGluten = Convert.ToInt32(r["algn_gluten"]),
                    algnCrust = Convert.ToInt32(r["algn_crust"]),
                    algnEggs = Convert.ToInt32(r["algn_eggs"]),
                    algnFish = Convert.ToInt32(r["algn_fish"]),
                    algnLupin = Convert.ToInt32(r["algn_lupin"]),
                    algnMilk = Convert.ToInt32(r["algn_milk"]),
                    algnMollusc = Convert.ToInt32(r["algn_mollusc"]),
                    algnMustard = Convert.ToInt32(r["algn_mustard"]),
                    algnPeanut = Convert.ToInt32(r["algn_peanut"]),
                    algnSesame = Convert.ToInt32(r["algn_sesame"]),
                    algnSoya = Convert.ToInt32(r["algn_soya"]),
                    algnSulphite = Convert.ToInt32(r["algn_sulphite"]),
                    algnTreenut = Convert.ToInt32(r["algn_treenut"]),
                    vegetarian = Convert.ToInt32(r["vegetarian"]),
                    vegan = Convert.ToInt32(r["vegan"])
                });
            }

            return models;
        }
    }
}
