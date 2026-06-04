using System.Drawing;

namespace CoreStoreCRM.Forms
{
    public partial class SupportTicketForm : Form
    {
        private Color PrimaryBlue = Color.FromArgb(0, 120, 212);
        private Color DarkGray = Color.FromArgb(64, 64, 64);
        private Color LightGray = Color.FromArgb(240, 240, 240);
        private TextBox txtTicketId;
        private TextBox txtSubject;
        private RichTextBox txtDescription;
        private ComboBox cmbPriority;
        private ComboBox cmbCategory;
        private Button btnSubmit;
        private Button btnCancel;

        public SupportTicketForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Создание запроса в поддержку";
            this.BackColor = LightGray;
            this.Font = new Font("Segoe UI", 10);

            // Панель заголовка
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 50;
            headerPanel.BackColor = PrimaryBlue;

            Label titleLabel = new Label();
            titleLabel.Text = "🎫 Создать запрос в поддержку";
            titleLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Padding = new Padding(15);

            headerPanel.Controls.Add(titleLabel);
            this.Controls.Add(headerPanel);

            // Основная панель с формой
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            mainPanel.AutoScroll = true;

            int yPos = 10;

            // ID тикета (только чтение)
            Label lblTicketId = new Label();
            lblTicketId.Text = "ID тикета:";
            lblTicketId.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTicketId.Location = new Point(10, yPos);
            lblTicketId.Size = new Size(150, 25);
            mainPanel.Controls.Add(lblTicketId);

            txtTicketId = new TextBox();
            txtTicketId.Text = "#" + DateTime.Now.Ticks.ToString().Substring(0, 8);
            txtTicketId.ReadOnly = true;
            txtTicketId.Location = new Point(170, yPos);
            txtTicketId.Size = new Size(300, 25);
            mainPanel.Controls.Add(txtTicketId);

            yPos += 35;

            // Категория
            Label lblCategory = new Label();
            lblCategory.Text = "Категория:";
            lblCategory.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCategory.Location = new Point(10, yPos);
            lblCategory.Size = new Size(150, 25);
            mainPanel.Controls.Add(lblCategory);

            cmbCategory = new ComboBox();
            cmbCategory.Items.AddRange(new[] { 
                "Техническая поддержка", 
                "Ошибка в системе", 
                "Запрос функции",
                "Вопрос по использованию",
                "Другое"
            });
            cmbCategory.SelectedIndex = 0;
            cmbCategory.Location = new Point(170, yPos);
            cmbCategory.Size = new Size(300, 25);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            mainPanel.Controls.Add(cmbCategory);

            yPos += 35;

            // Приоритет
            Label lblPriority = new Label();
            lblPriority.Text = "Приоритет:";
            lblPriority.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPriority.Location = new Point(10, yPos);
            lblPriority.Size = new Size(150, 25);
            mainPanel.Controls.Add(lblPriority);

            cmbPriority = new ComboBox();
            cmbPriority.Items.AddRange(new[] { "Низкий", "Средний", "Высокий", "Критический" });
            cmbPriority.SelectedIndex = 1;
            cmbPriority.Location = new Point(170, yPos);
            cmbPriority.Size = new Size(300, 25);
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            mainPanel.Controls.Add(cmbPriority);

            yPos += 35;

            // Тема
            Label lblSubject = new Label();
            lblSubject.Text = "Тема:";
            lblSubject.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubject.Location = new Point(10, yPos);
            lblSubject.Size = new Size(150, 25);
            mainPanel.Controls.Add(lblSubject);

            txtSubject = new TextBox();
            txtSubject.Location = new Point(170, yPos);
            txtSubject.Size = new Size(300, 25);
            txtSubject.MaxLength = 100;
            mainPanel.Controls.Add(txtSubject);

            yPos += 35;

            // Описание
            Label lblDescription = new Label();
            lblDescription.Text = "Описание:";
            lblDescription.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDescription.Location = new Point(10, yPos);
            lblDescription.Size = new Size(150, 25);
            mainPanel.Controls.Add(lblDescription);

            yPos += 25;

            txtDescription = new RichTextBox();
            txtDescription.Location = new Point(10, yPos);
            txtDescription.Size = new Size(460, 150);
            txtDescription.Font = new Font("Segoe UI", 9);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(txtDescription);

            yPos += 160;

            this.Controls.Add(mainPanel);

            // Панель с кнопками
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 50;
            buttonPanel.BackColor = Color.White;
            buttonPanel.BorderStyle = BorderStyle.FixedSingle;
            buttonPanel.Padding = new Padding(10);

            btnSubmit = new Button();
            btnSubmit.Text = "Отправить запрос";
            btnSubmit.Size = new Size(200, 35);
            btnSubmit.Location = new Point(250, 8);
            btnSubmit.BackColor = PrimaryBlue;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSubmit.Click += (s, e) => SubmitTicket();

            btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(460, 8);
            btnCancel.BackColor = DarkGray;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => this.Close();

            buttonPanel.Controls.Add(btnSubmit);
            buttonPanel.Controls.Add(btnCancel);
            this.Controls.Add(buttonPanel);
        }

        private void SubmitTicket()
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Пожалуйста, введите тему запроса", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание проблемы", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Здесь должна быть логика сохранения в БД
            string ticketInfo = $@"Новый запрос в поддержку:
ID: {txtTicketId.Text}
Категория: {cmbCategory.SelectedItem}
Приоритет: {cmbPriority.SelectedItem}
Тема: {txtSubject.Text}
Описание: {txtDescription.Text}
Дата: {DateTime.Now:dd.MM.yyyy HH:mm}
Пользователь: {SessionManager.CurrentUser?.Name ?? "Неизвестный"}";

            MessageBox.Show(ticketInfo, "Запрос отправлен", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
