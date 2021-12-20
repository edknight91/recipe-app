namespace RecipeApi.Models
{
    using System;
    using System.Data;
    using MySqlConnector;
    public class DbConnection : IDisposable
    {
        // Change password to your password in MySql!
        private const string CONNECTION_STRING = "Server=127.0.0.1;Database=recipeapi;Uid=root;Pwd=Developer!;";

        public MySqlConnection Connection { get; }

        public static DbConnection Current { get; set; }

        public DbConnection()
        {
            Connection = new MySqlConnection(CONNECTION_STRING);
            Connection.Open();
        }

        public DataTable GetAllRecipes()
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM recipe;";
            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetAllMeals()
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM meals;";
            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetAllIngredients()
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM ingredient;";
            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetAllRecipeIngredients()
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM recipe_ingredient;";
            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetAllShoplistMeals()
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM shoplist_meal_id;";
            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetAllShoplists()
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM shoplist;";
            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetAllSiteUsers()
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM site_user;";
            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetRecipeById(int recipeId)
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM recipe WHERE recipe_id=@RecipeId;";

            command.Parameters.AddWithValue("@RecipeId", recipeId);

            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetIngredientByRecipeId(int recipeId)
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT i.*, ri.quantity FROM ingredient i INNER JOIN recipe_ingredient ri ON ri.ingredient_id = i.ingredient_id WHERE ri.recipe_id = @RecipeId;";

            command.Parameters.AddWithValue("@RecipeId", recipeId);

            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public DataTable GetMealsByUserId(int siteUserId)
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "SELECT meal.meal_id, meal.recipe_id, recipe.title FROM meal INNER JOIN recipe ON meal.recipe_id = recipe.recipe_id WHERE meal.site_user_id = @siteUserId;";

            command.Parameters.AddWithValue("@SiteUserId", siteUserId);

            //            command.Exec

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(command);
            x.Fill(t);

            return t;
        }

        public void Dispose() => Connection.Dispose();
    }
}