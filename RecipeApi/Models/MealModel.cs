using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class MealModel
    {
        public int mealId { get; set; }

        public DateTime datePlaced { get; set; }

        public int recipeId { get; set; }

        public int siteUserId { get; set; }

        public static List<MealModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllMeals();

            List<MealModel> models = new List<MealModel>();

            foreach(DataRow r in data.Rows)
            {
                models.Add(new MealModel
                {
                    mealId = Convert.ToInt32(r["meal_id"]),
                    datePlaced = Convert.ToDateTime(r["date_placed"]),
                    recipeId = Convert.ToInt32(r["recipe_id"]),
                    siteUserId = Convert.ToInt32(r["site_user_id"])
                });
            }

            return models;
        }
    }
}
