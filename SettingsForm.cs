using System.Drawing;

namespace CoreStoreCRM.Forms
{
    public partial class SettingsForm : Form
    {
        private Color PrimaryBlue = Color.FromArgb(0, 120, 212);
        private Color DarkGray = Color.FromArgb(64, 64, 64);
        private Color LightGray = Color.FromArgb(240, 240, 240);
        private TabControl tabControl;
        private TabPage tabGeneral;
        private TabPage tabNotifications;
        private TabPage tabSecurity;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.BackColor = LightGray;
            this.Font = new Font("Segoe UI", 10);

            // Панель заголовка
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 50;
            headerPanel.BackColor = PrimaryBlue;

            Label titleLabel = new Label();
            titleLabel.Text = "⚙️ Настройки приложения";
            titleLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Padding = new Padding(15);

            headerPanel.Controls.Add(titleLabel);
            this.Controls.Add(headerPanel);

            // TabControl для разных категорий настроек
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.Padding = new Point(10, 10);

            // Вкладка "Общие"
            tabGeneral = new TabPage("Общие");
            CreateGeneralTab(tabGeneral);
            tabControl.TabPages.Add(tabGeneral);

            // Вкладка "Уведомления"
            tabNotifications = new TabPage("Уведомления");
            CreateNotificationsTab(tabNotifications);
            tabControl.TabPages.Add(tabNotifications);

            // Вкладка "Безопасность"
            tabSecurity = new TabPage("Безопасность");
            CreateSecurityTab(tabSecurity);
            tabControl.TabPages.Add(tabSecurity);

            this.Controls.Add(tabControl);

            // Панель с кнопками
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 50;
            buttonPanel.BackColor = Color.White;
            buttonPanel.BorderStyle = BorderStyle.FixedSingle;
            buttonPanel.Padding = new Padding(10);

            Button btnSave = new Button();
            btnSave.Text = "Сохранить";
            btnSave.Size = new Size(120, 35);
            btnSave.Location = new Point(500, 8);
            btnSave.BackColor = PrimaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += (s, e) => SaveSettings();

            Button btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(630, 8);
            btnCancel.BackColor = DarkGray;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => this.Close();

            buttonPanel.Controls.Add(btnSave);
            buttonPanel.Controls.Add(btnCancel);
            this.Controls.Add(buttonPanel);
        }

        private void CreateGeneralTab(TabPage tab)
        {
            int yPos = 20;

            Label lblTheme = new Label();
            lblTheme.Text = "Тема оформления:";
            lblTheme.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTheme.Location = new Point(20, yPos);
            lblTheme.Size = new Size(200, 25);
            tab.Controls.Add(lblTheme);

            ComboBox cmbTheme = new ComboBox();
            cmbTheme.Items.AddRange(new[] { "Синяя", "Темная", "Светлая" });
            cmbTheme.SelectedIndex = 0;
            cmbTheme.Location = new Point(250, yPos);
            cmbTheme.Size = new Size(300, 25);
            cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            tab.Controls.Add(cmbTheme);

            yPos += 40;

            Label lblLanguage = new Label();
            lblLanguage.Text = "Язык интерфейса:";
            lblLanguage.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblLanguage.Location = new Point(20, yPos);
            lblLanguage.Size = new Size(200, 25);
            tab.Controls.Add(lblLanguage);

            ComboBox cmbLanguage = new ComboBox();
            cmbLanguage.Items.AddRange(new[] { "Русский", "English" });
            cmbLanguage.SelectedIndex = 0;
            cmbLanguage.Location = new Point(250, yPos);
            cmbLanguage.Size = new Size(300, 25);
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            tab.Controls.Add(cmbLanguage);

            yPos += 40;

            Label lblStartup = new Label();
            lblStartup.Text = "Запуск при старте ОС:";
            lblStartup.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblStartup.Location = new Point(20, yPos);
            lblStartup.Size = new Size(200, 25);
            tab.Controls.Add(lblStartup);

            CheckBox chkStartup = new CheckBox();
            chkStartup.Location = new Point(250, yPos + 3);
            chkStartup.Size = new Size(20, 20);
            chkStartup.Checked = false;
            tab.Controls.Add(chkStartup);
        }

        private void CreateNotificationsTab(TabPage tab)
        {
            int yPos = 20;

            Label lblSoundNotif = new Label();
            lblSoundNotif.Text = "Звуковые уведомления:";
            lblSoundNotif.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSoundNotif.Location = new Point(20, yPos);
            lblSoundNotif.Size = new Size(200, 25);
            tab.Controls.Add(lblSoundNotif);

            CheckBox chkSound = new CheckBox();
            chkSound.Location = new Point(250, yPos + 3);
            chkSound.Size = new Size(20, 20);
            chkSound.Checked = true;
            tab.Controls.Add(chkSound);

            yPos += 40;

            Label lblDesktopNotif = new Label();
            lblDesktopNotif.Text = "Всплывающие уведомления:";
            lblDesktopNotif.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDesktopNotif.Location = new Point(20, yPos);
            lblDesktopNotif.Size = new Size(200, 25);
            tab.Controls.Add(lblDesktopNotif);

            CheckBox chkDesktop = new CheckBox();
            chkDesktop.Location = new Point(250, yPos + 3);
            chkDesktop.Size = new Size(20, 20);
            chkDesktop.Checked = true;
            tab.Controls.Add(chkDesktop);

            yPos += 40;

            Label lblEmailNotif = new Label();
            lblEmailNotif.Text = "Email уведомления:";
            lblEmailNotif.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblEmailNotif.Location = new Point(20, yPos);
            lblEmailNotif.Size = new Size(200, 25);
            tab.Controls.Add(lblEmailNotif);

            CheckBox chkEmail = new CheckBox();
            chkEmail.Location = new Point(250, yPos + 3);
            chkEmail.Size = new Size(20, 20);
            chkEmail.Checked = true;
            tab.Controls.Add(chkEmail);

            yPos += 40;

            Label lblFrequency = new Label();
            lblFrequency.Text = "Частота проверки:";
            lblFrequency.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFrequency.Location = new Point(20, yPos);
            lblFrequency.Size = new Size(200, 25);
            tab.Controls.Add(lblFrequency);

            ComboBox cmbFrequency = new ComboBox();
            cmbFrequency.Items.AddRange(new[] { "Каждую минуту", "Каждые 5 минут", "Каждые 10 минут", "Каждый час" });
            cmbFrequency.SelectedIndex = 1;
            cmbFrequency.Location = new Point(250, yPos);
            cmbFrequency.Size = new Size(300, 25);
            cmbFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            tab.Controls.Add(cmbFrequency);
        }

        private void CreateSecurityTab(TabPage tab)
        {
            int yPos = 20;

            Label lblPassword = new Label();
            lblPassword.Text = "Изменить пароль:";
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPassword.Location = new Point(20, yPos);
            lblPassword.Size = new Size(200, 25);
            tab.Controls.Add(lblPassword);

            Button btnChangePassword = new Button();
            btnChangePassword.Text = "Изменить пароль";
            btnChangePassword.Size = new Size(150, 35);
            btnChangePassword.Location = new Point(250, yPos - 5);
            btnChangePassword.BackColor = PrimaryBlue;
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.Click += (s, e) => ChangePassword();
            tab.Controls.Add(btnChangePassword);

            yPos += 50;

            Label lblTwoFactor = new Label();
            lblTwoFactor.Text = "Двухфакторная аутентификация:";
            lblTwoFactor.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTwoFactor.Location = new Point(20, yPos);
            lblTwoFactor.Size = new Size(250, 25);
            tab.Controls.Add(lblTwoFactor);

            CheckBox chkTwoFactor = new CheckBox();
            chkTwoFactor.Location = new Point(250, yPos + 3);
            chkTwoFactor.Size = new Size(20, 20);
            chkTwoFactor.Checked = false;
            tab.Controls.Add(chkTwoFactor);

            yPos += 50;

            Label lblSessions = new Label();
            lblSessions.Text = "Активные сеансы:";
            lblSessions.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSessions.Location = new Point(20, yPos);
            lblSessions.Size = new Size(200, 25);
            tab.Controls.Add(lblSessions);

            Button btnSessions = new Button();
            btnSessions.Text = "Управление сеансами";
            btnSessions.Size = new Size(150, 35);
            btnSessions.Location = new Point(250, yPos - 5);
            btnSessions.BackColor = PrimaryBlue;
            btnSessions.ForeColor = Color.White;
            btnSessions.FlatStyle = FlatStyle.Flat;
            btnSessions.FlatAppearance.BorderSize = 0;
            btnSessions.Cursor = Cursors.Hand;
            btnSessions.Click += (s, e) => ManageSessions();
            tab.Controls.Add(btnSessions);
        }

        private void SaveSettings()
        {
            MessageBox.Show("Настройки сохранены успешно!", "Успех", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ChangePassword()
        {
            MessageBox.Show("Функция изменения пароля находится в разработке", "Информация", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ManageSessions()
        {
            MessageBox.Show("Функция управления сеансами находится в разработке", "Информация", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
