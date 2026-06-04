using System.Drawing;
using CoreStoreCRM.DataAccess;
using CoreStoreCRM.Models;

namespace CoreStoreCRM.Forms
{
    public partial class NotificationForm : Form
    {
        private NotificationRepository notificationRepo = new NotificationRepository();
        private Color PrimaryBlue = Color.FromArgb(0, 120, 212);
        private Color DarkGray = Color.FromArgb(64, 64, 64);
        private Color LightGray = Color.FromArgb(240, 240, 240);
        private Color SuccessGreen = Color.FromArgb(0, 150, 100);
        private Color WarningOrange = Color.FromArgb(255, 140, 0);
        private Color ErrorRed = Color.FromArgb(200, 50, 50);
        private List<Notification> currentNotifications;

        public NotificationForm()
        {
            InitializeComponent();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            this.Text = "Уведомления";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);
            this.BackColor = LightGray;
            this.Font = new Font("Segoe UI", 10);

            InitializeUI();
            LoadNotifications();
        }

        private void InitializeUI()
        {
            // Панель заголовка с иконой и кнопками
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 60;
            headerPanel.BackColor = PrimaryBlue;
            headerPanel.Padding = new Padding(10);

            Label titleLabel = new Label();
            titleLabel.Text = "📬 Уведомления";
            titleLabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(10, 15);

            Button btnMarkAllRead = new Button();
            btnMarkAllRead.Text = "Отметить все как прочитанные";
            btnMarkAllRead.Font = new Font("Segoe UI", 9);
            btnMarkAllRead.Size = new Size(180, 30);
            btnMarkAllRead.Location = new Point(600, 15);
            btnMarkAllRead.BackColor = Color.White;
            btnMarkAllRead.ForeColor = PrimaryBlue;
            btnMarkAllRead.FlatStyle = FlatStyle.Flat;
            btnMarkAllRead.FlatAppearance.BorderSize = 1;
            btnMarkAllRead.Cursor = Cursors.Hand;
            btnMarkAllRead.Click += (s, e) => MarkAllAsRead();

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(btnMarkAllRead);
            this.Controls.Add(headerPanel);

            // ListBox для уведомлений
            ListBox notificationList = new ListBox();
            notificationList.Name = "notificationList";
            notificationList.Dock = DockStyle.Fill;
            notificationList.BackColor = Color.White;
            notificationList.Font = new Font("Segoe UI", 10);
            notificationList.ItemHeight = 60;
            notificationList.DrawMode = DrawMode.OwnerDrawFixed;
            notificationList.DrawItem += NotificationList_DrawItem;
            notificationList.SelectedIndexChanged += (s, e) => 
            {
                if (notificationList.SelectedIndex >= 0)
                {
                    var notif = currentNotifications[notificationList.SelectedIndex];
                    if (!notif.IsRead)
                    {
                        notificationRepo.MarkAsRead(notif.NotificationId);
                        LoadNotifications();
                    }
                }
            };

            this.Controls.Add(notificationList);

            // Панель кнопок в нижней части
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 50;
            buttonPanel.BackColor = Color.White;
            buttonPanel.BorderStyle = BorderStyle.FixedSingle;
            buttonPanel.Padding = new Padding(10);

            Button btnClear = new Button();
            btnClear.Text = "Очистить старые";
            btnClear.Font = new Font("Segoe UI", 9);
            btnClear.Size = new Size(120, 35);
            btnClear.Location = new Point(10, 8);
            btnClear.BackColor = WarningOrange;
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Cursor = Cursors.Hand;
            btnClear.Click += (s, e) => ClearOldNotifications();

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Font = new Font("Segoe UI", 9);
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(690, 8);
            btnClose.BackColor = DarkGray;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => this.Close();

            buttonPanel.Controls.Add(btnClear);
            buttonPanel.Controls.Add(btnClose);
            this.Controls.Add(buttonPanel);
        }

        private void LoadNotifications()
        {
            if (SessionManager.CurrentUser == null) return;

            currentNotifications = notificationRepo.GetUserNotifications(SessionManager.CurrentUser.UserId);
            ListBox notificationList = this.Controls["notificationList"] as ListBox;
            
            if (notificationList != null)
            {
                notificationList.Items.Clear();
                foreach (var notif in currentNotifications)
                {
                    notificationList.Items.Add(notif);
                }
            }
        }

        private void NotificationList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= currentNotifications.Count) return;

            ListBox listBox = sender as ListBox;
            Notification item = currentNotifications[e.Index];

            e.DrawBackground();

            // Фон в зависимости от статуса прочтения
            if (!item.IsRead)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 240, 255)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }

            // Индикатор статуса слева
            Color statusColor = GetStatusColor(item.Type);
            e.Graphics.FillRectangle(new SolidBrush(statusColor), e.Bounds.Left, e.Bounds.Top, 4, e.Bounds.Height);

            // Неприочитанный индикатор
            if (!item.IsRead)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), e.Bounds.Left + 10, e.Bounds.Top + 8, 10, 10);
            }

            // Название уведомления
            Font titleFont = new Font("Segoe UI", 11, FontStyle.Bold);
            e.Graphics.DrawString(item.Title, titleFont, new SolidBrush(DarkGray), 
                e.Bounds.Left + 30, e.Bounds.Top + 5);

            // Текст сообщения
            Font messageFont = new Font("Segoe UI", 9);
            string messageText = item.Message.Length > 100 
                ? item.Message.Substring(0, 100) + "..." 
                : item.Message;
            e.Graphics.DrawString(messageText, messageFont, new SolidBrush(Color.Gray), 
                e.Bounds.Left + 30, e.Bounds.Top + 25);

            // Время
            Font timeFont = new Font("Segoe UI", 8, FontStyle.Italic);
            string timeText = FormatTime(item.CreatedAt);
            e.Graphics.DrawString(timeText, timeFont, new SolidBrush(Color.DarkGray), 
                e.Bounds.Right - 200, e.Bounds.Top + 25);

            e.DrawFocusRectangle();
        }

        private Color GetStatusColor(string type)
        {
            return type switch
            {
                "success" => SuccessGreen,
                "warning" => WarningOrange,
                "error" => ErrorRed,
                _ => PrimaryBlue
            };
        }

        private string FormatTime(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now - dateTime;
            
            if (timeSpan.TotalMinutes < 1)
                return "только что";
            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} мин назад";
            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} час назад";
            if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} дн назад";
            
            return dateTime.ToString("dd.MM.yyyy");
        }

        private void MarkAllAsRead()
        {
            if (SessionManager.CurrentUser == null) return;

            if (notificationRepo.MarkAllAsRead(SessionManager.CurrentUser.UserId))
            {
                MessageBox.Show("Все уведомления отмечены как прочитанные", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNotifications();
            }
        }

        private void ClearOldNotifications()
        {
            if (MessageBox.Show("Удалить уведомления старше 30 дней?", "Подтверждение", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (notificationRepo.ClearOldNotifications(30))
                {
                    MessageBox.Show("Старые уведомления удалены", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNotifications();
                }
            }
        }
    }
}
