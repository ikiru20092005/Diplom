namespace CoreStoreCRM.Forms
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonRegister;
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
            this.labelPassword = new Label();
            this.textBoxPassword = new TextBox();
            this.labelConfirmPassword = new Label();
            this.textBoxConfirmPassword = new TextBox();
            this.buttonRegister = new Button();
            this.buttonCancel = new Button();
            this.SuspendLayout();

            // labelName
            this.labelName.AutoSize = true;
            this.labelName.Location = new Point(20, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new Size(45, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Имя:";

            // textBoxName
            this.textBoxName.Location = new Point(20, 40);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new Size(300, 23);
            this.textBoxName.TabIndex = 1;

            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new Point(20, 70);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new Size(47, 15);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Email:";

            // textBoxEmail
            this.textBoxEmail.Location = new Point(20, 90);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new Size(300, 23);
            this.textBoxEmail.TabIndex = 3;

            // labelPhone
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new Point(20, 120);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new Size(74, 15);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Телефон:";

            // textBoxPhone
            this.textBoxPhone.Location = new Point(20, 140);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new Size(300, 23);
            this.textBoxPhone.TabIndex = 5;

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new Point(20, 170);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new Size(65, 15);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Пароль:";

            // textBoxPassword
            this.textBoxPassword.Location = new Point(20, 190);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new Size(300, 23);
            this.textBoxPassword.TabIndex = 7;

            // labelConfirmPassword
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new Point(20, 220);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new Size(117, 15);
            this.labelConfirmPassword.TabIndex = 8;
            this.labelConfirmPassword.Text = "Подтвердить пароль:";

            // textBoxConfirmPassword
            this.textBoxConfirmPassword.Location = new Point(20, 240);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new Size(300, 23);
            this.textBoxConfirmPassword.TabIndex = 9;

            // buttonRegister
            this.buttonRegister.Location = new Point(100, 280);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new Size(100, 35);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = "Регистрация";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new EventHandler(this.buttonRegister_Click);

            // buttonCancel
            this.buttonCancel.Location = new Point(220, 280);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(100, 35);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);

            // RegistrationForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(360, 330);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.Load += new EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
