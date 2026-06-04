using MySql.Data.MySqlClient;
using System;

namespace CoreStoreCRM.DataAccess
{
    public class DatabaseHelper
    {
        private static readonly string ConnectionString = "Server=localhost;Database=corestorecrm;uid=root;pwd=;";

        public static MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool TestConnection()
        {
            using (var connection = GetConnection())
            {
                return connection != null && connection.State == System.Data.ConnectionState.Open;
            }
        }
    }
}
