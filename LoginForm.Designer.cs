namespace CoreStoreCRM.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonRegister;
        private Button buttonExit;
        private Label labelEmail;
        private Label labelPassword;

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
            this.textBoxEmail = new TextBox();
            this.textBoxPassword = new TextBox();
            this.buttonLogin = new Button();
            this.buttonRegister = new Button();
            this.buttonExit = new Button();
            this.labelEmail = new Label();
            this.labelPassword = new Label();
            this.SuspendLayout();

            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new Point(30, 30);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new Size(40, 15);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email:";

            // textBoxEmail
            this.textBoxEmail.Location = new Point(30, 50);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new Size(300, 23);
            this.textBoxEmail.TabIndex = 1;

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new Point(30, 90);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new Size(57, 15);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Пароль:";

            // textBoxPassword
            this.textBoxPassword.Location = new Point(30, 110);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new Size(300, 23);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;

            // buttonLogin
            this.buttonLogin.Location = new Point(30, 160);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new Size(100, 40);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Вход";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new EventHandler(this.buttonLogin_Click);

            // buttonRegister
            this.buttonRegister.Location = new Point(140, 160);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new Size(100, 40);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "Регистрация";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new EventHandler(this.buttonRegister_Click);

            // buttonExit
            this.buttonExit.Location = new Point(250, 160);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new Size(80, 40);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new EventHandler(this.buttonExit_Click);

            // LoginForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(360, 220);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonExit);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.Load += new EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
