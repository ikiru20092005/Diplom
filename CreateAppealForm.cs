using CoreStoreCRM.DataAccess;

namespace CoreStoreCRM.Forms
{
    public partial class CreateAppealForm : Form
    {
        private AppealRepository appealRepo = new AppealRepository();

        public CreateAppealForm()
        {
            InitializeComponent();
        }

        private void CreateAppealForm_Load(object sender, EventArgs e)
        {
            this.Text = "Создать новое обращение";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Заполняем типы обращений
            comboBoxAppealType.Items.Add("Вопрос");
            comboBoxAppealType.Items.Add("Проблема");
            comboBoxAppealType.Items.Add("Техническая поддержка");
            comboBoxAppealType.SelectedIndex = 0;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMessage.Text))
            {
                MessageBox.Show("Введите описание обращения", "Ошибка");
                return;
            }

            int appealTypeId = comboBoxAppealType.SelectedIndex + 1;

            if (appealRepo.CreateAppeal(SessionManager.CurrentUser.UserId, appealTypeId, textBoxMessage.Text))
            {
                MessageBox.Show("Обращение создано успешно", "Успех");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
