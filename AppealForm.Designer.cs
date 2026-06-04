namespace CoreStoreCRM.Forms
{
    partial class AppealForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewAppeals;
        private ListBox listBoxMessages;
        private TextBox textBoxMessage;
        private Button buttonViewMessages;
        private Button buttonSendMessage;
        private Button buttonCloseAppeal;
        private Button buttonCreateAppeal;
        private Button buttonRefresh;
        private Label labelAppeals;
        private Label labelMessages;
        private Label labelNewMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewAppeals = new DataGridView();
            this.listBoxMessages = new ListBox();
            this.textBoxMessage = new TextBox();
            this.buttonViewMessages = new Button();
            this.buttonSendMessage = new Button();
            this.buttonCloseAppeal = new Button();
            this.buttonCreateAppeal = new Button();
            this.buttonRefresh = new Button();
            this.labelAppeals = new Label();
            this.labelMessages = new Label();
            this.labelNewMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppeals)).BeginInit();
            this.SuspendLayout();

            // labelAppeals
            this.labelAppeals.AutoSize = true;
            this.labelAppeals.Location = new Point(10, 10);
            this.labelAppeals.Name = "labelAppeals";
            this.labelAppeals.Size = new Size(71, 15);
            this.labelAppeals.TabIndex = 0;
            this.labelAppeals.Text = "Обращения:";

            // dataGridViewAppeals
            this.dataGridViewAppeals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppeals.Location = new Point(10, 30);
            this.dataGridViewAppeals.Name = "dataGridViewAppeals";
            this.dataGridViewAppeals.Size = new Size(450, 300);
            this.dataGridViewAppeals.TabIndex = 1;
            this.dataGridViewAppeals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAppeals.MultiSelect = false;

            // labelMessages
            this.labelMessages.AutoSize = true;
            this.labelMessages.Location = new Point(470, 10);
            this.labelMessages.Name = "labelMessages";
            this.labelMessages.Size = new Size(81, 15);
            this.labelMessages.TabIndex = 2;
            this.labelMessages.Text = "Сообщения:";

            // listBoxMessages
            this.listBoxMessages.Location = new Point(470, 30);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new Size(400, 300);
            this.listBoxMessages.TabIndex = 3;

            // labelNewMessage
            this.labelNewMessage.AutoSize = true;
            this.labelNewMessage.Location = new Point(470, 350);
            this.labelNewMessage.Name = "labelNewMessage";
            this.labelNewMessage.Size = new Size(113, 15);
            this.labelNewMessage.TabIndex = 4;
            this.labelNewMessage.Text = "Новое сообщение:";

            // textBoxMessage
            this.textBoxMessage.Location = new Point(470, 370);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new Size(400, 100);
            this.textBoxMessage.TabIndex = 5;

            // buttonViewMessages
            this.buttonViewMessages.Location = new Point(10, 350);
            this.buttonViewMessages.Name = "buttonViewMessages";
            this.buttonViewMessages.Size = new Size(100, 30);
            this.buttonViewMessages.TabIndex = 6;
            this.buttonViewMessages.Text = "Просмотреть";
            this.buttonViewMessages.UseVisualStyleBackColor = true;
            this.buttonViewMessages.Click += new EventHandler(this.buttonViewMessages_Click);

            // buttonSendMessage
            this.buttonSendMessage.Location = new Point(470, 480);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new Size(100, 30);
            this.buttonSendMessage.TabIndex = 7;
            this.buttonSendMessage.Text = "Отправить";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new EventHandler(this.buttonSendMessage_Click);

            // buttonCloseAppeal
            this.buttonCloseAppeal.Location = new Point(120, 350);
            this.buttonCloseAppeal.Name = "buttonCloseAppeal";
            this.buttonCloseAppeal.Size = new Size(100, 30);
            this.buttonCloseAppeal.TabIndex = 8;
            this.buttonCloseAppeal.Text = "Закрыть";
            this.buttonCloseAppeal.UseVisualStyleBackColor = true;
            this.buttonCloseAppeal.Click += new EventHandler(this.buttonCloseAppeal_Click);

            // buttonCreateAppeal
            this.buttonCreateAppeal.Location = new Point(230, 350);
            this.buttonCreateAppeal.Name = "buttonCreateAppeal";
            this.buttonCreateAppeal.Size = new Size(100, 30);
            this.buttonCreateAppeal.TabIndex = 9;
            this.buttonCreateAppeal.Text = "Создать";
            this.buttonCreateAppeal.UseVisualStyleBackColor = true;
            this.buttonCreateAppeal.Click += new EventHandler(this.buttonCreateAppeal_Click);

            // buttonRefresh
            this.buttonRefresh.Location = new Point(340, 350);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new Size(100, 30);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);

            // AppealForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(882, 520);
            this.Controls.Add(this.labelAppeals);
            this.Controls.Add(this.dataGridViewAppeals);
            this.Controls.Add(this.labelMessages);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.labelNewMessage);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonViewMessages);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.buttonCloseAppeal);
            this.Controls.Add(this.buttonCreateAppeal);
            this.Controls.Add(this.buttonRefresh);
            this.Name = "AppealForm";
            this.Text = "Обращения";
            this.Load += new EventHandler(this.AppealForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppeals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
