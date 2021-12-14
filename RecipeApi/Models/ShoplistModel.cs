using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class ShoplistModel
    {
        public int shoplistId { get; set; }

        public int siteUserId { get; set; }

        public static List<ShoplistModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllShoplists();

            List<ShoplistModel> models = new List<ShoplistModel>();

            foreach(DataRow r in data.Rows)
            {
                models.Add(new ShoplistModel
                {
                    shoplistId = Convert.ToInt32(r["shoplist_id"]),
                    siteUserId = Convert.ToInt32(r["site_user_id"])
                });
            }

            return models;
        }
    }
}
