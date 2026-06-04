using CoreStoreCRM.DataAccess;
using CoreStoreCRM.Utilities;

namespace CoreStoreCRM.Forms
{
    public partial class LoginForm : Form
    {
        private Form parentForm;

        public LoginForm(Form parent = null)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = "CoreStore CRM - Вход";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 10);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Пожалуйста, заполните оба поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userRepo = new UserRepository();
            // Пароль передается в открытом виде, хэширование происходит в БД
            var user = userRepo.GetUserByCredentials(textBoxEmail.Text, textBoxPassword.Text);

            if (user != null)
            {
                // Сохранение пользователя
                SessionManager.CurrentUser = user;

                if (parentForm != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неправильный email или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
                textBoxEmail.Focus();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (parentForm == null)
            {
                Application.Exit();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
