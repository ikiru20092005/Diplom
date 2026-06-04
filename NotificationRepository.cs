using MySql.Data.MySqlClient;
using CoreStoreCRM.Models;
using System;
using System.Collections.Generic;

namespace CoreStoreCRM.DataAccess
{
    public class NotificationRepository
    {
        private string connectionString = "Server=localhost;Database=corestorecrm;Uid=root;Pwd=;";

        public List<Notification> GetUserNotifications(int userId)
        {
            var notifications = new List<Notification>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM notification 
                                   WHERE user_id = @userId 
                                   ORDER BY created_at DESC 
                                   LIMIT 50";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                notifications.Add(new Notification
                                {
                                    NotificationId = Convert.ToInt32(reader["notification_id"]),
                                    UserId = Convert.ToInt32(reader["user_id"]),
                                    Title = reader["title"].ToString(),
                                    Message = reader["message"].ToString(),
                                    IsRead = Convert.ToBoolean(reader["is_read"]),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    Type = reader["notification_type"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при загрузке уведомлений: {ex.Message}");
            }
            return notifications;
        }

        public int GetUnreadNotificationsCount(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM notification WHERE user_id = @userId AND is_read = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        object result = cmd.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при подсчете уведомлений: {ex.Message}");
                return 0;
            }
        }

        public bool MarkAsRead(int notificationId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE notification SET is_read = 1 WHERE notification_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", notificationId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при отметке уведомления: {ex.Message}");
                return false;
            }
        }

        public bool MarkAllAsRead(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE notification SET is_read = 1 WHERE user_id = @userId AND is_read = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при отметке всех уведомлений: {ex.Message}");
                return false;
            }
        }

        public bool CreateNotification(int userId, string title, string message, string type = "info")
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO notification (user_id, title, message, is_read, created_at, notification_type) 
                                   VALUES (@userId, @title, @message, 0, NOW(), @type)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@message", message);
                        cmd.Parameters.AddWithValue("@type", type);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при создании уведомления: {ex.Message}");
                return false;
            }
        }

        public bool DeleteNotification(int notificationId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM notification WHERE notification_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", notificationId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при удалении уведомления: {ex.Message}");
                return false;
            }
        }

        public bool ClearOldNotifications(int daysOld = 30)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM notification WHERE created_at < DATE_SUB(NOW(), INTERVAL @days DAY)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@days", daysOld);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при очистке уведомлений: {ex.Message}");
                return false;
            }
        }
    }
}
