namespace CoreStoreCRM.Forms
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Button buttonSave;
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
            this.labelName = new Label();
            this.textBoxName = new TextBox();
            this.labelEmail = new Label();
            this.textBoxEmail = new TextBox();
            this.labelPhone = new Label();
            this.textBoxPhone = new TextBox();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            this.SuspendLayout();

            // labelName
            this.labelName.AutoSize = true;
            this.labelName.Location = new Point(20, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new Size(31, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "ФИО:";

            // textBoxName
            this.textBoxName.Location = new Point(20, 40);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new Size(300, 23);
            this.textBoxName.TabIndex = 1;

            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new Point(20, 80);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new Size(44, 15);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Email:";

            // textBoxEmail
            this.textBoxEmail.Location = new Point(20, 100);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new Size(300, 23);
            this.textBoxEmail.TabIndex = 3;

            // labelPhone
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new Point(20, 140);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new Size(67, 15);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Телефон:";

            // textBoxPhone
            this.textBoxPhone.Location = new Point(20, 160);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new Size(300, 23);
            this.textBoxPhone.TabIndex = 5;

            // buttonSave
            this.buttonSave.Location = new Point(80, 220);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new Size(100, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new EventHandler(this.buttonSave_Click);

            // buttonCancel
            this.buttonCancel.Location = new Point(200, 220);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(100, 30);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);

            // ProfileForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(340, 280);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "ProfileForm";
            this.Text = "Профиль";
            this.Load += new EventHandler(this.ProfileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
