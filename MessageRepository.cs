using MySql.Data.MySqlClient;
using CoreStoreCRM.Models;
using System;
using System.Collections.Generic;

namespace CoreStoreCRM.DataAccess
{
    public class MessageRepository
    {
        public List<Models.Message> GetAppealMessages(int appealId)
        {
            var messages = new List<Models.Message>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return messages;

                    var command = new MySqlCommand("GetAppealMessages", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_appealId", appealId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(new Models.Message
                            {
                                MessageId = (int)reader["messageId"],
                                CreatedAt = (DateTime)reader["createdAt"],
                                IsRead = Convert.ToBoolean(reader["isRead"]),
                                IsFromManager = Convert.ToBoolean(reader["isFromManager"]),
                                MessageText = reader["messageText"].ToString(),
                                UserId = (int)reader["userId"],
                                UserName = reader["name"].ToString(),
                                AppealId = (int)reader["appealId"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении сообщений: {ex.Message}", "Ошибка");
            }
            return messages;
        }

        public bool SendMessage(int appealId, int userId, bool isFromManager, string messageText)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    var command = new MySqlCommand("SendMessage", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_appealId", appealId);
                    command.Parameters.AddWithValue("@p_userId", userId);
                    command.Parameters.AddWithValue("@p_isFromManager", isFromManager ? 1 : 0);
                    command.Parameters.AddWithValue("@p_messageText", messageText);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке сообщения: {ex.Message}", "Ошибка");
                return false;
            }
        }

        public bool MarkMessagesAsRead(int appealId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    var command = new MySqlCommand("MarkMessagesAsRead", connection)
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
                MessageBox.Show($"Ошибка при отметке сообщений как прочитанных: {ex.Message}", "Ошибка");
                return false;
            }
        }

        public List<Notification> GetNotifications(int userId)
        {
            var notifications = new List<Notification>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return notifications;

                    var command = new MySqlCommand("GetNotifications", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new Notification
                            {
                                MessageId = (int)reader["messageId"],
                                CreatedAt = (DateTime)reader["createdAt"],
                                MessageText = reader["messageText"].ToString(),
                                AppealId = (int)reader["appealId"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении уведомлений: {ex.Message}", "Ошибка");
            }
            return notifications;
        }

        public List<Attachment> GetFilesByMessage(int messageId)
        {
            var attachments = new List<Attachment>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return attachments;

                    var command = new MySqlCommand("GetFilesByMessage", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_messageId", messageId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            attachments.Add(new Attachment
                            {
                                AttachmentId = (int)reader["attachmentId"],
                                FileName = reader["fileName"].ToString(),
                                FilePath = reader["filePath"].ToString(),
                                MessageId = (int)reader["messageId"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении вложений: {ex.Message}", "Ошибка");
            }
            return attachments;
        }

        public bool InsertFile(int messageId, string fileName, string filePath)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    var command = new MySqlCommand("InsertFile", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_messageId", messageId);
                    command.Parameters.AddWithValue("@p_fileName", fileName);
                    command.Parameters.AddWithValue("@p_filePath", filePath);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении файла: {ex.Message}", "Ошибка");
                return false;
            }
        }
    }
}
