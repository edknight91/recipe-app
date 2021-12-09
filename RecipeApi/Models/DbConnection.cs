namespace RecipeApi.Models
{
    using System;
    using System.Data;
    using MySqlConnector;
    public class DbConnection : IDisposable
    {
        private const string CONNECTION_STRING = "Server=127.0.0.1;Database=myshop;Uid=root;Pwd=Developer!;";

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