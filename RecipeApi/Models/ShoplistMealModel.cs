using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class ShoplistMealModel
    {
        public int shoplistMealId { get; set; }

        public int shoplistId { get; set; }
        public int mealId { get; set; }

        public static List<ShoplistMealModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllShoplistMeals();

            List<ShoplistMealModel> models = new List<ShoplistMealModel>();

            foreach(DataRow r in data.Rows)
            {
                models.Add(new ShoplistMealModel
                {
                    shoplistMealId = Convert.ToInt32(r["shoplist_meal_id"]),
                    shoplistId = Convert.ToInt32(r["shoplist_id"]),
                    mealId = Convert.ToInt32(r["meal_id"])
                });
            }

            return models;
        }
    }
}
