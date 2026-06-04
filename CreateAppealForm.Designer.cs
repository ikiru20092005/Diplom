namespace CoreStoreCRM.Forms
{
    partial class CreateAppealForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelType;
        private ComboBox comboBoxAppealType;
        private Label labelMessage;
        private TextBox textBoxMessage;
        private Button buttonCreate;
        private Button buttonCancel;

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
            this.labelType = new Label();
            this.comboBoxAppealType = new ComboBox();
            this.labelMessage = new Label();
            this.textBoxMessage = new TextBox();
            this.buttonCreate = new Button();
            this.buttonCancel = new Button();
            this.SuspendLayout();

            // labelType
            this.labelType.AutoSize = true;
            this.labelType.Location = new Point(20, 20);
            this.labelType.Name = "labelType";
            this.labelType.Size = new Size(67, 15);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Тип обращения:";

            // comboBoxAppealType
            this.comboBoxAppealType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxAppealType.FormattingEnabled = true;
            this.comboBoxAppealType.Location = new Point(20, 40);
            this.comboBoxAppealType.Name = "comboBoxAppealType";
            this.comboBoxAppealType.Size = new Size(340, 23);
            this.comboBoxAppealType.TabIndex = 1;

            // labelMessage
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new Point(20, 80);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new Size(74, 15);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "Описание:";

            // textBoxMessage
            this.textBoxMessage.Location = new Point(20, 100);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new Size(340, 200);
            this.textBoxMessage.TabIndex = 3;

            // buttonCreate
            this.buttonCreate.Location = new Point(100, 320);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new Size(100, 30);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new EventHandler(this.buttonCreate_Click);

            // buttonCancel
            this.buttonCancel.Location = new Point(210, 320);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(100, 30);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);

            // CreateAppealForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(380, 370);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.comboBoxAppealType);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonCancel);
            this.Name = "CreateAppealForm";
            this.Text = "Создать обращение";
            this.Load += new EventHandler(this.CreateAppealForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
