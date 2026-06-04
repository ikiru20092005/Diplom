using System.Drawing;

namespace CoreStoreCRM.Forms
{
    public partial class NotificationForm : Form
    {
        private Color PrimaryBlue = Color.FromArgb(0, 120, 212);
        private Color DarkGray = Color.FromArgb(64, 64, 64);
        private Color LightGray = Color.FromArgb(240, 240, 240);

        public NotificationForm()
        {
            InitializeComponent();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            this.Text = "Уведомления";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 500);
            this.BackColor = LightGray;
            this.Font = new Font("Segoe UI", 10);

            InitializeUI();
            LoadNotifications();
        }

        private void InitializeUI()
        {
            // Панель заголовка
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 50;
            headerPanel.BackColor = PrimaryBlue;

            Label titleLabel = new Label();
            titleLabel.Text = "Уведомления";
            titleLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Padding = new Padding(15);
            titleLabel.Dock = DockStyle.Fill;

            headerPanel.Controls.Add(titleLabel);
            this.Controls.Add(headerPanel);

            // ListBox для уведомлений
            ListBox notificationList = new ListBox();
            notificationList.Name = "notificationList";
            notificationList.Dock = DockStyle.Fill;
            notificationList.BackColor = Color.White;
            notificationList.Font = new Font("Segoe UI", 10);
            notificationList.ItemHeight = 40;
            notificationList.DrawMode = DrawMode.OwnerDrawFixed;
            notificationList.DrawItem += NotificationList_DrawItem;

            this.Controls.Add(notificationList);

            // Панель кнопок
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 50;
            buttonPanel.BackColor = Color.White;
            buttonPanel.BorderStyle = BorderStyle.FixedSingle;

            Button btnMarkAsRead = new Button();
            btnMarkAsRead.Text = "Отметить как прочитанное";
            btnMarkAsRead.Size = new Size(200, 35);
            btnMarkAsRead.Location = new Point(10, 8);
            btnMarkAsRead.BackColor = PrimaryBlue;
            btnMarkAsRead.ForeColor = Color.White;
            btnMarkAsRead.FlatStyle = FlatStyle.Flat;
            btnMarkAsRead.FlatAppearance.BorderSize = 0;
            btnMarkAsRead.Cursor = Cursors.Hand;
            btnMarkAsRead.Click += (s, e) => MarkAsRead();

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(480, 8);
            btnClose.BackColor = Color.LightGray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => this.Close();

            buttonPanel.Controls.Add(btnMarkAsRead);
            buttonPanel.Controls.Add(btnClose);
            this.Controls.Add(buttonPanel);
        }

        private void LoadNotifications()
        {
            ListBox notificationList = this.Controls["notificationList"] as ListBox;
            if (notificationList == null) return;

            var notifications = new[]
            {
                new { Title = "Новый заказ", Message = "У вас новый заказ #12345", Time = "2 часа назад", IsRead = false },
                new { Title = "Сообщение от менеджера", Message = "Ответ на ваше обращение", Time = "5 часов назад", IsRead = false },
                new { Title = "Товар отправлен", Message = "Ваш заказ отправлен", Time = "1 день назад", IsRead = true },
                new { Title = "Система", Message = "Плановое обслуживание завершено", Time = "3 дня назад", IsRead = true },
            };

            notificationList.Items.Clear();
            foreach (var notif in notifications)
            {
                notificationList.Items.Add(notif);
            }
        }

        private void NotificationList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ListBox listBox = sender as ListBox;
            dynamic item = listBox.Items[e.Index];

            e.DrawBackground();

            if (!item.IsRead)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 240, 255)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }

            if (!item.IsRead)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), e.Bounds.Left + 5, e.Bounds.Top + 10, 8, 8);
            }

            Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            e.Graphics.DrawString(item.Title, titleFont, new SolidBrush(Color.Black), e.Bounds.Left + 20, e.Bounds.Top + 5);

            Font messageFont = new Font("Segoe UI", 9);
            e.Graphics.DrawString(item.Message, messageFont, new SolidBrush(Color.Gray), e.Bounds.Left + 20, e.Bounds.Top + 22);

            Font timeFont = new Font("Segoe UI", 8, FontStyle.Italic);
            e.Graphics.DrawString(item.Time, timeFont, new SolidBrush(Color.DarkGray), e.Bounds.Right - 150, e.Bounds.Top + 22);

            e.DrawFocusRectangle();
        }

        private void MarkAsRead()
        {
            MessageBox.Show("Уведомления отмечены как прочитанные", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNotifications();
            Invalidate();
        }
    }
}
