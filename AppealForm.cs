using CoreStoreCRM.DataAccess;
using CoreStoreCRM.Models;

namespace CoreStoreCRM.Forms
{
    public partial class AppealForm : Form
    {
        private AppealRepository appealRepo = new AppealRepository();
        private MessageRepository messageRepo = new MessageRepository();
        private List<Appeal> currentAppeals;
        private Appeal selectedAppeal;

        public AppealForm()
        {
            InitializeComponent();
        }

        private void AppealForm_Load(object sender, EventArgs e)
        {
            this.Text = "Управление обращениями";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 600);

            LoadAppeals();
        }

        private void LoadAppeals()
        {
            if (SessionManager.IsManager)
            {
                // Менеджер видит все обращения
                currentAppeals = appealRepo.GetManagerAppeals();
            }
            else
            {
                // Обычный пользователь видит только свои обращения
                currentAppeals = appealRepo.GetUserAppeals(SessionManager.CurrentUser.UserId);
            }

            RefreshAppealsList();
        }

        private void RefreshAppealsList()
        {
            dataGridViewAppeals.DataSource = null;
            dataGridViewAppeals.DataSource = currentAppeals;
            dataGridViewAppeals.Columns["AppealId"].HeaderText = "ID";
            dataGridViewAppeals.Columns["ClientName"].HeaderText = "Клиент";
            dataGridViewAppeals.Columns["AppealType"].HeaderText = "Тип";
            dataGridViewAppeals.Columns["AppealStatus"].HeaderText = "Статус";

            if (SessionManager.IsManager)
            {
                dataGridViewAppeals.Columns["ManagerName"].HeaderText = "Менеджер";
            }
            dataGridViewAppeals.Columns["CreateDate"].HeaderText = "Дата создания";
        }

        private void buttonViewMessages_Click(object sender, EventArgs e)
        {
            if (dataGridViewAppeals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите обращение", "Ошибка");
                return;
            }

            int appealId = (int)dataGridViewAppeals.SelectedRows[0].Cells["AppealId"].Value;
            selectedAppeal = currentAppeals.FirstOrDefault(a => a.AppealId == appealId);

            if (selectedAppeal != null)
            {
                LoadMessages(appealId);
            }
        }

        private void LoadMessages(int appealId)
        {
            var messages = messageRepo.GetAppealMessages(appealId);
            listBoxMessages.Items.Clear();

            foreach (var msg in messages)
            {
                string sender = msg.IsFromManager ? "[Менеджер]" : "[Клиент]";
                listBoxMessages.Items.Add($"{sender} {msg.CreatedAt:dd.MM.yyyy HH:mm}: {msg.MessageText}");
            }

            messageRepo.MarkMessagesAsRead(appealId);
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMessage.Text))
            {
                MessageBox.Show("Введите текст сообщения", "Ошибка");
                return;
            }

            if (selectedAppeal == null)
            {
                MessageBox.Show("Выберите обращение", "Ошибка");
                return;
            }

            bool isFromManager = SessionManager.IsManager;
            if (messageRepo.SendMessage(selectedAppeal.AppealId, SessionManager.CurrentUser.UserId, isFromManager, textBoxMessage.Text))
            {
                textBoxMessage.Clear();
                LoadMessages(selectedAppeal.AppealId);
                MessageBox.Show("Сообщение отправлено", "Успех");
            }
        }

        private void buttonCloseAppeal_Click(object sender, EventArgs e)
        {
            if (selectedAppeal == null)
            {
                MessageBox.Show("Выберите обращение", "Ошибка");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите закрыть это обращение?", "Подтверждение", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (appealRepo.CloseAppeal(selectedAppeal.AppealId))
                {
                    MessageBox.Show("Обращение закрыто", "Успех");
                    LoadAppeals();
                    listBoxMessages.Items.Clear();
                    textBoxMessage.Clear();
                }
            }
        }

        private void buttonCreateAppeal_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsManager)
            {
                CreateAppealForm createForm = new CreateAppealForm();
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAppeals();
                }
            }
            else
            {
                MessageBox.Show("Менеджер не может создавать обращения", "Ошибка");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadAppeals();
        }
    }
}
