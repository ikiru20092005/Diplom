using MySql.Data.MySqlClient;
using CoreStoreCRM.Models;
using System;
using System.Collections.Generic;

namespace CoreStoreCRM.DataAccess
{
    public class AppealRepository
    {
        public List<Appeal> GetManagerAppeals()
        {
            var appeals = new List<Appeal>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return appeals;

                    var command = new MySqlCommand("GetManagerAppeals", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appeals.Add(new Appeal
                            {
                                AppealId = (int)reader["appealId"],
                                ClientName = reader["clientName"].ToString(),
                                AppealType = reader["appealType"].ToString(),
                                AppealStatus = reader["appealStatus"].ToString(),
                                ManagerName = reader["managerName"]?.ToString() ?? "Не назначен",
                                CreateDate = (DateTime)reader["createDate"],
                                ChangeDate = (DateTime)reader["changeDate"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении обращений: {ex.Message}", "Ошибка");
            }
            return appeals;
        }

        public List<Appeal> GetUserAppeals(int userId)
        {
            var appeals = new List<Appeal>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return appeals;

                    var command = new MySqlCommand("GetUserAppeals", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appeals.Add(new Appeal
                            {
                                AppealId = (int)reader["appealId"],
                                AppealType = reader["appealType"].ToString(),
                                AppealStatus = reader["appealStatus"].ToString(),
                                CreateDate = (DateTime)reader["createDate"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении обращений пользователя: {ex.Message}", "Ошибка");
            }
            return appeals;
        }

        public bool CreateAppeal(int userId, int appealTypeId, string messageText)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    var command = new MySqlCommand("CreateAppeal", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_userId", userId);
                    command.Parameters.AddWithValue("@p_appealTypeId", appealTypeId);
                    command.Parameters.AddWithValue("@p_messageText", messageText);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании обращения: {ex.Message}", "Ошибка");
                return false;
            }
        }

        public bool AssignAppeal(int appealId, int employeeId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    var command = new MySqlCommand("AssignAppeal", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_appealId", appealId);
                    command.Parameters.AddWithValue("@p_employeeId", employeeId);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при назначении обращения: {ex.Message}", "Ошибка");
                return false;
            }
        }

        public bool CloseAppeal(int appealId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    var command = new MySqlCommand("CloseAppeal", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_appealId", appealId);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии обращения: {ex.Message}", "Ошибка");
                return false;
            }
        }

        public List<Appeal> GetClosedAppealsReport()
        {
            var appeals = new List<Appeal>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return appeals;

                    var command = new MySqlCommand("GetClosedAppealsReport", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appeals.Add(new Appeal
                            {
                                AppealId = (int)reader["appealId"],
                                CreateDate = (DateTime)reader["createDate"],
                                CloseDate = reader["closeDate"] != DBNull.Value ? (DateTime)reader["closeDate"] : null,
                                AppealType = reader["type"].ToString(),
                                ClientName = reader["client"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении отчета: {ex.Message}", "Ошибка");
            }
            return appeals;
        }
    }
}
