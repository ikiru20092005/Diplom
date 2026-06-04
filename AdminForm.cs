using CoreStoreCRM.DataAccess;

namespace CoreStoreCRM.Forms
{
    public partial class AdminForm : Form
    {
        private AppealRepository appealRepo = new AppealRepository();
        private TabControl tabControl;
        private TabPage tabPageReports;
        private TabPage tabPageUsers;
        private DataGridView dataGridViewReports;
        private Button buttonRefreshReports;
        private Button buttonExportReport;
        private Label labelReports;
        private Label labelUsers;
        private ListBox listBoxUsers;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tabControl = new TabControl();
            this.tabPageReports = new TabPage();
            this.tabPageUsers = new TabPage();
            this.dataGridViewReports = new DataGridView();
            this.buttonRefreshReports = new Button();
            this.buttonExportReport = new Button();
            this.labelReports = new Label();
            this.labelUsers = new Label();
            this.listBoxUsers = new ListBox();
            this.tabControl.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Controls.Add(this.tabPageUsers);
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Location = new Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(900, 600);
            this.tabControl.TabIndex = 0;

            // tabPageReports
            this.tabPageReports.Controls.Add(this.labelReports);
            this.tabPageReports.Controls.Add(this.dataGridViewReports);
            this.tabPageReports.Controls.Add(this.buttonRefreshReports);
            this.tabPageReports.Controls.Add(this.buttonExportReport);
            this.tabPageReports.Location = new Point(4, 24);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new Size(892, 572);
            this.tabPageReports.TabIndex = 0;
            this.tabPageReports.Text = "Отчеты";
            this.tabPageReports.UseVisualStyleBackColor = true;

            // labelReports
            this.labelReports.AutoSize = true;
            this.labelReports.Location = new Point(10, 10);
            this.labelReports.Name = "labelReports";
            this.labelReports.Size = new Size(151, 15);
            this.labelReports.TabIndex = 0;
            this.labelReports.Text = "Закрытые обращения:";

            // dataGridViewReports
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Location = new Point(10, 30);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.Size = new Size(872, 480);
            this.dataGridViewReports.TabIndex = 1;

            // buttonRefreshReports
            this.buttonRefreshReports.Location = new Point(10, 520);
            this.buttonRefreshReports.Name = "buttonRefreshReports";
            this.buttonRefreshReports.Size = new Size(100, 30);
            this.buttonRefreshReports.TabIndex = 2;
            this.buttonRefreshReports.Text = "Обновить";
            this.buttonRefreshReports.UseVisualStyleBackColor = true;
            this.buttonRefreshReports.Click += new EventHandler(this.buttonRefreshReports_Click);

            // buttonExportReport
            this.buttonExportReport.Location = new Point(120, 520);
            this.buttonExportReport.Name = "buttonExportReport";
            this.buttonExportReport.Size = new Size(100, 30);
            this.buttonExportReport.TabIndex = 3;
            this.buttonExportReport.Text = "Экспорт";
            this.buttonExportReport.UseVisualStyleBackColor = true;
            this.buttonExportReport.Click += new EventHandler(this.buttonExportReport_Click);

            // tabPageUsers
            this.tabPageUsers.Controls.Add(this.labelUsers);
            this.tabPageUsers.Controls.Add(this.listBoxUsers);
            this.tabPageUsers.Location = new Point(4, 24);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Size = new Size(892, 572);
            this.tabPageUsers.TabIndex = 1;
            this.tabPageUsers.Text = "Пользователи";
            this.tabPageUsers.UseVisualStyleBackColor = true;

            // labelUsers
            this.labelUsers.AutoSize = true;
            this.labelUsers.Location = new Point(10, 10);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new Size(81, 15);
            this.labelUsers.TabIndex = 0;
            this.labelUsers.Text = "Пользователи:";

            // listBoxUsers
            this.listBoxUsers.Location = new Point(10, 30);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new Size(872, 520);
            this.listBoxUsers.TabIndex = 1;

            // AdminForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "AdminForm";
            this.Text = "Администрирование";
            this.Load += new EventHandler(this.AdminForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageReports.ResumeLayout(false);
            this.tabPageReports.PerformLayout();
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 600);

            LoadReports();
        }

        private void LoadReports()
        {
            try
            {
                var appeals = appealRepo.GetClosedAppealsReport();

                dataGridViewReports.DataSource = null;
                dataGridViewReports.DataSource = appeals;

                if (dataGridViewReports.Columns.Count > 0)
                {
                    dataGridViewReports.Columns["AppealId"].HeaderText = "ID";
                    dataGridViewReports.Columns["CreateDate"].HeaderText = "Дата создания";
                    dataGridViewReports.Columns["CloseDate"].HeaderText = "Дата закрытия";
                    dataGridViewReports.Columns["AppealType"].HeaderText = "Тип";
                    dataGridViewReports.Columns["ClientName"].HeaderText = "Клиент";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отчетов: {ex.Message}");
            }
        }

        private void buttonRefreshReports_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void buttonExportReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Экспорт отчетов в разработке", "Информация");
        }
    }
}
