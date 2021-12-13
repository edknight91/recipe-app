using System;
using System.Data;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class SiteUserModel
    {
        public int siteUserId { get; set; }

        public string username { get; set; }

        public static List<SiteUserModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllSiteUsers();

            List<SiteUserModel> models = new List<SiteUserModel>();

            foreach(DataRow r in data.Rows)
            {
                models.Add(new SiteUserModel
                {
                    siteUserId = Convert.ToInt32(r["site_user_id"]),
                    username = Convert.ToString(r["username"])
                });
            }

            return models;
        }
    }
}
