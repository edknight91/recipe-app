namespace RecipeApi.Models
{
    using System;
    using System.Data;
    using MySqlConnector;
    public class DbConnection : IDisposable
    {
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

        public void CreateRecipe(string title, string method)
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "INSERT INTO recipe (title, method) VALUES (@title, @method);";

            command.Parameters.Add(new MySqlParameter("@title", title));
            command.Parameters.Add(new MySqlParameter("@method", method));

            command.ExecuteNonQuery();

        }

        public void UpdateRecipe(string title, string method)
        {
            MySqlCommand command = this.Connection.CreateCommand();
            command.CommandText = "UPDATE recipe SET title = @title, method = @method";

            command.Parameters.Add(new MySqlParameter("@title", title));
            command.Parameters.Add(new MySqlParameter("@method", method));

            command.ExecuteNonQuery();
        }


        public void Dispose() => Connection.Dispose();
    }
}