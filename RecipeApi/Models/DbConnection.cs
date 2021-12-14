namespace RecipeApi.Models
{
    using System;
    using System.Data;
    using MySqlConnector;
    public class DbConnection : IDisposable
    {
        // Change password to your password in MySql!
        private const string CONNECTION_STRING = "Server=127.0.0.1;Database=recipeapi;Uid=root;Pwd=Coders!23;";

        public MySqlConnection Connection { get; }

        public static DbConnection Current { get; set; }

        public DbConnection()
        {
            Connection = new MySqlConnection(CONNECTION_STRING);
            Connection.Open();
        }

        public void Dispose() => Connection.Dispose();
    }
}