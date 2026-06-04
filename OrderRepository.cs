using MySql.Data.MySqlClient;
using CoreStoreCRM.Models;
using System;
using System.Collections.Generic;

namespace CoreStoreCRM.DataAccess
{
    public class OrderRepository
    {
        public List<Order> GetClientOrders(int userId)
        {
            var orders = new List<Order>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return orders;

                    var command = new MySqlCommand("GetClientOrders", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderId = (int)reader["orderId"],
                                StartDate = (DateTime)reader["startDate"],
                                Amount = (decimal)reader["amount"],
                                StatusName = reader["statusName"].ToString(),
                                Address = reader["address"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении заказов: {ex.Message}", "Ошибка");
            }
            return orders;
        }
    }
}
