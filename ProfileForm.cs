using CoreStoreCRM.DataAccess;

namespace CoreStoreCRM.Forms
{
    public partial class ProfileForm : Form
    {
        private UserRepository userRepo = new UserRepository();

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            this.Text = "Профиль пользователя";
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            var user = userRepo.GetUserById(SessionManager.CurrentUser.UserId);

            if (user != null)
            {
                textBoxName.Text = user.Name;
                textBoxEmail.Text = user.Email;
                textBoxPhone.Text = user.Phone;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || 
                string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка");
                return;
            }

            if (userRepo.UpdateUserProfile(
                SessionManager.CurrentUser.UserId,
                textBoxName.Text,
                textBoxEmail.Text,
                textBoxPhone.Text))
            {
                MessageBox.Show("Профиль обновлен успешно", "Успех");
                SessionManager.CurrentUser.Name = textBoxName.Text;
                SessionManager.CurrentUser.Email = textBoxEmail.Text;
                SessionManager.CurrentUser.Phone = textBoxPhone.Text;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoadUserProfile();
        }
    }
}
