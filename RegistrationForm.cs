using CoreStoreCRM.DataAccess;
using CoreStoreCRM.Utilities;
using CoreStoreCRM.Models;
using System.Drawing;

namespace CoreStoreCRM.Forms
{
    public partial class RegistrationForm : Form
    {
        private Color PrimaryBlue = Color.FromArgb(0, 120, 212);
        private Color DarkGray = Color.FromArgb(64, 64, 64);

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            this.Text = "CoreStore CRM - Регистрация";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 10);

            SetupUI();
        }

        private void SetupUI()
        {
            // Стилизация кнопок
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = PrimaryBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    btn.Cursor = Cursors.Hand;
                }
                else if (ctrl is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 10);
                }
                else if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 10);
                    lbl.ForeColor = DarkGray;
                }
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || !textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Пожалуйста, введите корректный email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Пожалуйста, введите номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text) || textBoxPassword.Text.Length < 6)
            {
                MessageBox.Show("Пароль должен быть не менее 6 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return;
            }

            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxConfirmPassword.Focus();
                return;
            }

            // Регистрация пользователя
            try
            {
                var userRepo = new UserRepository();
                string hashedPassword = PasswordHelper.HashPassword(textBoxPassword.Text);

                // Создаем нового пользователя с ролью "Клиент" (обычно roleId = 1)
                var newUser = new User
                {
                    Name = textBoxName.Text,
                    Email = textBoxEmail.Text,
                    Phone = textBoxPhone.Text,
                    RoleId = 1  // Клиент
                };

                // Вызываем репозиторий для регистрации (нужно создать этот метод)
                bool registered = userRepo.RegisterUser(newUser, hashedPassword);

                if (registered)
                {
                    MessageBox.Show("Регистрация успешна! Теперь вы можете войти.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при регистрации. Email может быть уже зарегистрирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
