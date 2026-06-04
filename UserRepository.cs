using MySql.Data.MySqlClient;
using CoreStoreCRM.Models;
using System;
using System.Collections.Generic;

namespace CoreStoreCRM.DataAccess
{
    public class UserRepository
    {
        public User GetUserByCredentials(string email, string password)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return null;

                    // Сначала получаем пользователя по email
                    var command = new MySqlCommand(
                        "SELECT userId, email, name, phone, roleId, passwordHash FROM `user` WHERE email = @email",
                        connection);
                    command.Parameters.AddWithValue("@email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var passwordHash = reader["passwordHash"].ToString();

                            // Проверяем пароль используя BCrypt
                            if (Utilities.PasswordHelper.VerifyPassword(password, passwordHash))
                            {
                                return new User
                                {
                                    UserId = (int)reader["userId"],
                                    Email = reader["email"].ToString(),
                                    Name = reader["name"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    RoleId = (int)reader["roleId"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении пользователя: {ex.Message}", "Ошибка");
            }
            return null;
        }

        public User GetUserById(int userId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return null;

                    var command = new MySqlCommand("GetClientInfo", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = (int)reader["userId"],
                                Name = reader["name"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении информации пользователя: {ex.Message}", "Ошибка");
            }
            return null;
        }

        public bool UpdateUserProfile(int userId, string name, string email, string phone)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    var command = new MySqlCommand("sp_UpdateUserProfile", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@p_userId", userId);
                    command.Parameters.AddWithValue("@p_name", name);
                    command.Parameters.AddWithValue("@p_email", email);
                    command.Parameters.AddWithValue("@p_phone", phone);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении профиля: {ex.Message}", "Ошибка");
                return false;
            }
        }

        public bool RegisterUser(User user, string passwordHash)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    if (connection == null) return false;

                    // Проверяем, не существует ли уже пользователь с таким email
                    var checkCommand = new MySqlCommand("SELECT COUNT(*) FROM `user` WHERE email = @email", connection);
                    checkCommand.Parameters.AddWithValue("@email", user.Email);

                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким email уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Вставляем нового пользователя
                    var command = new MySqlCommand(
                        "INSERT INTO `user` (name, email, phone, roleId, passwordHash) VALUES (@name, @email, @phone, @roleId, @passwordHash)",
                        connection);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@phone", user.Phone);
                    command.Parameters.AddWithValue("@roleId", user.RoleId);
                    command.Parameters.AddWithValue("@passwordHash", passwordHash);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка");
                return false;
            }
        }
    }
}
