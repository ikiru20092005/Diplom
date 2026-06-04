using CoreStoreCRM.Forms;
using System.Drawing;

namespace CoreStoreCRM
{
    public partial class MainForm : Form
    {
        private AppealForm appealForm;
        private ProfileForm profileForm;
        private OrdersForm ordersForm;
        private AdminForm adminForm;
        private NotificationForm notificationForm;
        private System.Windows.Forms.Timer notificationTimer;
        private int unreadNotificationsCount = 0;
        private Color PrimaryBlue = Color.FromArgb(0, 120, 212);  
        private Color DarkBlue = Color.FromArgb(0, 90, 158); 
        private Color LightGray = Color.FromArgb(240, 240, 240);
        private Color DarkGray = Color.FromArgb(64, 64, 64);

        public MainForm()
        {
            InitializeComponent();
            SetupTheme();
        }

        private void SetupTheme()
        {
            this.BackColor = LightGray;
            this.ForeColor = DarkGray;
            this.Font = new Font("Segoe UI", 10);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {

                ShowLoginScreen();
                return;
            }


            this.Text = "CoreStore CRM";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1400, 900);
            this.MinimumSize = new Size(1000, 600);
            InitializeUI();
            LoadProducts();
            UpdateMenuByRole();
            LoadNotifications();

            // Таймер для обновления уведомлений
            notificationTimer = new System.Windows.Forms.Timer();
            notificationTimer.Interval = 5000; 
            notificationTimer.Tick += (s, e) => UpdateNotificationBadge();
            notificationTimer.Start();

            statusLabelUser.Text = $"Пользователь: {SessionManager.CurrentUser.Name}";
        }

        private void ShowLoginScreen()
        {
            this.Hide();
            LoginForm loginForm = new LoginForm(this);
            loginForm.ShowDialog();

            if (SessionManager.CurrentUser != null)
            {
                this.Show();
                MainForm_Load(null, null);
            }
            else
            {
                this.Close();
            }
        }

        private void InitializeUI()
        {
            panelMenu.BackColor = PrimaryBlue;

            // Стилизация кнопок меню
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is Button btn && btn.Name != "buttonProfileIcon" && btn.Name != "buttonNotificationIcon")
                {
                    btn.ForeColor = Color.White;
                    btn.BackColor = PrimaryBlue;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        private void UpdateMenuByRole()
        {
            if (SessionManager.IsManager)
            {
                buttonAppeals.Visible = true;
                buttonAdmin.Visible = false;
            }
            else if (SessionManager.IsAdmin)
            {
                buttonAppeals.Visible = true;
                buttonAdmin.Visible = true;
            }
            else
            {
                buttonAppeals.Visible = true;
                buttonAdmin.Visible = false;
            }
        }

        private void LoadProducts()
        {
            // Демо-товары для визуализации
            var products = new[]
            {
                new { Name = "ASUS VivoBook 15", Price = "45,999₽", Image = "Notebook1.jpg", Description = "15.6\" FHD Display" },
                new { Name = "ASUS VivoBook Pro", Price = "62,999₽", Image = "Notebook2.jpg", Description = "15.6\" OLED Display" },
                new { Name = "Игровые наушники", Price = "12,999₽", Image = "gamerHeadphones.jpg", Description = "RGB, 7.1 Surround" },
                new { Name = "Bluetooth наушники", Price = "8,999₽", Image = "headphoneBluetooth.jpg", Description = "40 часов батареи" },
                new { Name = "Gaming Mouse", Price = "3,999₽", Image = "mouse.jpg", Description = "16000 DPI" },
            };

            panelProducts.Controls.Clear();
            int x = 10, y = 10;

            foreach (var product in products)
            {
                AddProductCard(product.Name, product.Price, product.Description, x, y, product.Image);
                x += 270;
                if (x > panelProducts.Width - 300)
                {
                    x = 10;
                    y += 200;
                }
            }
        }

        private void AddProductCard(string name, string price, string description, int x, int y, string imageName)
        {
            Panel cardPanel = new Panel();
            cardPanel.Size = new Size(250, 180);
            cardPanel.Location = new Point(x, y);
            cardPanel.BackColor = Color.White;
            cardPanel.BorderStyle = BorderStyle.FixedSingle;
            cardPanel.Tag = name;

            Label labelName = new Label();
            labelName.Text = name;
            labelName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            labelName.Size = new Size(230, 40);
            labelName.Location = new Point(10, 10);
            labelName.AutoSize = false;
            labelName.TextAlign = ContentAlignment.TopLeft;

            Label labelDesc = new Label();
            labelDesc.Text = description;
            labelDesc.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            labelDesc.Size = new Size(230, 30);
            labelDesc.Location = new Point(10, 50);
            labelDesc.ForeColor = Color.Gray;

            Label labelPrice = new Label();
            labelPrice.Text = price;
            labelPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            labelPrice.Size = new Size(100, 25);
            labelPrice.Location = new Point(10, 80);
            labelPrice.ForeColor = PrimaryBlue;

            Button btnAddCart = new Button();
            btnAddCart.Text = "В корзину";
            btnAddCart.Font = new Font("Segoe UI", 9);
            btnAddCart.Size = new Size(220, 30);
            btnAddCart.Location = new Point(10, 145);
            btnAddCart.BackColor = PrimaryBlue;
            btnAddCart.ForeColor = Color.White;
            btnAddCart.FlatStyle = FlatStyle.Flat;
            btnAddCart.FlatAppearance.BorderSize = 0;
            btnAddCart.Cursor = Cursors.Hand;
            btnAddCart.Click += (s, e) => MessageBox.Show($"'{name}' добавлен в корзину", "Корзина", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cardPanel.Controls.Add(labelName);
            cardPanel.Controls.Add(labelDesc);
            cardPanel.Controls.Add(labelPrice);
            cardPanel.Controls.Add(btnAddCart);

            panelProducts.Controls.Add(cardPanel);
        }

        private void LoadNotifications()
        {
            UpdateNotificationBadge();
        }

        private void UpdateNotificationBadge()
        {
            if (buttonNotificationIcon != null && buttonNotificationIcon.Controls.Count > 0)
            {
                var redDot = buttonNotificationIcon.Controls[0] as Panel;
                if (redDot != null)
                {
                    redDot.Visible = unreadNotificationsCount > 0;
                }
            }
        }

        private void buttonAppeals_Click(object sender, EventArgs e)
        {
            if (appealForm == null || appealForm.IsDisposed)
            {
                appealForm = new AppealForm();
            }
            appealForm.Show();
            appealForm.Focus();
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            if (profileForm == null || profileForm.IsDisposed)
            {
                profileForm = new ProfileForm();
            }
            profileForm.Show();
            profileForm.Focus();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            if (ordersForm == null || ordersForm.IsDisposed)
            {
                ordersForm = new OrdersForm();
            }
            ordersForm.Show();
            ordersForm.Focus();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin)
            {
                MessageBox.Show("У вас нет прав администратора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (adminForm == null || adminForm.IsDisposed)
            {
                adminForm = new AdminForm();
            }
            adminForm.Show();
            adminForm.Focus();
        }

        private void buttonProfileIcon_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                ShowLoginScreen();
            }
            else
            {
                if (profileForm == null || profileForm.IsDisposed)
                {
                    profileForm = new ProfileForm();
                }
                profileForm.Show();
                profileForm.Focus();
            }
        }

        private void buttonNotificationIcon_Click(object sender, EventArgs e)
        {
            if (notificationForm == null || notificationForm.IsDisposed)
            {
                notificationForm = new NotificationForm();
            }
            notificationForm.Show();
            notificationForm.Focus();
        }

        private void buttonSupport_Click(object sender, EventArgs e)
        {
            KnowledgeBaseForm kbForm = new KnowledgeBaseForm();
            kbForm.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.Logout();
                notificationTimer?.Stop();
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notificationTimer?.Stop();
            appealForm?.Close();
            profileForm?.Close();
            ordersForm?.Close();
            adminForm?.Close();
            notificationForm?.Close();
        }
    }
}
