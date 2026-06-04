namespace CoreStoreCRM
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button buttonAppeals;
        private Button buttonProfile;
        private Button buttonOrders;
        private Button buttonAdmin;
        private Button buttonSupport;
        private Button buttonProfileIcon;
        private Button buttonNotificationIcon;
        private Button buttonLogout;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabelUser;
        private Panel panelMenu;
        private Panel panelProducts;

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
            this.panelMenu = new Panel();
            this.buttonLogout = new Button();
            this.buttonAdmin = new Button();
            this.buttonOrders = new Button();
            this.buttonProfile = new Button();
            this.buttonAppeals = new Button();
            this.buttonSupport = new Button();
            this.buttonNotificationIcon = new Button();
            this.redDot = new Panel();
            this.buttonProfileIcon = new Button();
            this.panelProducts = new Panel();
            this.statusStrip = new StatusStrip();
            this.statusLabelUser = new ToolStripStatusLabel();
            this.pictureBox1 = new PictureBox();
            this.panelMenu.SuspendLayout();
            this.buttonNotificationIcon.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = Color.FromArgb(0, 120, 212);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.buttonLogout);
            this.panelMenu.Controls.Add(this.buttonAdmin);
            this.panelMenu.Controls.Add(this.buttonOrders);
            this.panelMenu.Controls.Add(this.buttonProfile);
            this.panelMenu.Controls.Add(this.buttonAppeals);
            this.panelMenu.Controls.Add(this.buttonSupport);
            this.panelMenu.Controls.Add(this.buttonNotificationIcon);
            this.panelMenu.Controls.Add(this.buttonProfileIcon);
            this.panelMenu.Dock = DockStyle.Top;
            this.panelMenu.Location = new Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new Size(1400, 80);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = Color.FromArgb(139, 0, 0);
            this.buttonLogout.Cursor = Cursors.Hand;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = FlatStyle.Flat;
            this.buttonLogout.Font = new Font("Segoe UI", 10F);
            this.buttonLogout.ForeColor = Color.White;
            this.buttonLogout.Location = new Point(1320, 25);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new Size(60, 35);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Выход";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += this.buttonLogout_Click;
            // 
            // buttonAdmin
            // 
            this.buttonAdmin.BackColor = Color.FromArgb(0, 120, 212);
            this.buttonAdmin.Cursor = Cursors.Hand;
            this.buttonAdmin.FlatAppearance.BorderSize = 0;
            this.buttonAdmin.FlatStyle = FlatStyle.Flat;
            this.buttonAdmin.Font = new Font("Segoe UI", 10F);
            this.buttonAdmin.ForeColor = Color.White;
            this.buttonAdmin.Location = new Point(670, 25);
            this.buttonAdmin.Name = "buttonAdmin";
            this.buttonAdmin.Size = new Size(120, 35);
            this.buttonAdmin.TabIndex = 3;
            this.buttonAdmin.Text = "Администрация";
            this.buttonAdmin.UseVisualStyleBackColor = false;
            this.buttonAdmin.Click += this.buttonAdmin_Click;
            // 
            // buttonOrders
            // 
            this.buttonOrders.BackColor = Color.FromArgb(0, 120, 212);
            this.buttonOrders.Cursor = Cursors.Hand;
            this.buttonOrders.FlatAppearance.BorderSize = 0;
            this.buttonOrders.FlatStyle = FlatStyle.Flat;
            this.buttonOrders.Font = new Font("Segoe UI", 10F);
            this.buttonOrders.ForeColor = Color.White;
            this.buttonOrders.Location = new Point(540, 25);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new Size(120, 35);
            this.buttonOrders.TabIndex = 2;
            this.buttonOrders.Text = "Заказы";
            this.buttonOrders.UseVisualStyleBackColor = false;
            this.buttonOrders.Click += this.buttonOrders_Click;
            // 
            // buttonProfile
            // 
            this.buttonProfile.BackColor = Color.FromArgb(0, 120, 212);
            this.buttonProfile.Cursor = Cursors.Hand;
            this.buttonProfile.FlatAppearance.BorderSize = 0;
            this.buttonProfile.FlatStyle = FlatStyle.Flat;
            this.buttonProfile.Font = new Font("Segoe UI", 10F);
            this.buttonProfile.ForeColor = Color.White;
            this.buttonProfile.Location = new Point(410, 25);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new Size(120, 35);
            this.buttonProfile.TabIndex = 1;
            this.buttonProfile.Text = "Профиль";
            this.buttonProfile.UseVisualStyleBackColor = false;
            this.buttonProfile.Click += this.buttonProfile_Click;
            // 
            // buttonAppeals
            // 
            this.buttonAppeals.BackColor = Color.FromArgb(0, 120, 212);
            this.buttonAppeals.Cursor = Cursors.Hand;
            this.buttonAppeals.FlatAppearance.BorderSize = 0;
            this.buttonAppeals.FlatStyle = FlatStyle.Flat;
            this.buttonAppeals.Font = new Font("Segoe UI", 10F);
            this.buttonAppeals.ForeColor = Color.White;
            this.buttonAppeals.Location = new Point(280, 25);
            this.buttonAppeals.Name = "buttonAppeals";
            this.buttonAppeals.Size = new Size(120, 35);
            this.buttonAppeals.TabIndex = 0;
            this.buttonAppeals.Text = "Обращения";
            this.buttonAppeals.UseVisualStyleBackColor = false;
            this.buttonAppeals.Click += this.buttonAppeals_Click;
            // 
            // buttonSupport
            // 
            this.buttonSupport.BackColor = Color.FromArgb(0, 120, 212);
            this.buttonSupport.Cursor = Cursors.Hand;
            this.buttonSupport.FlatAppearance.BorderSize = 0;
            this.buttonSupport.FlatStyle = FlatStyle.Flat;
            this.buttonSupport.Font = new Font("Segoe UI", 10F);
            this.buttonSupport.ForeColor = Color.White;
            this.buttonSupport.Location = new Point(800, 25);
            this.buttonSupport.Name = "buttonSupport";
            this.buttonSupport.Size = new Size(120, 35);
            this.buttonSupport.TabIndex = 4;
            this.buttonSupport.Text = "Поддержка";
            this.buttonSupport.UseVisualStyleBackColor = false;
            this.buttonSupport.Click += this.buttonSupport_Click;
            // 
            // buttonNotificationIcon
            // 
            this.buttonNotificationIcon.BackColor = Color.FromArgb(0, 120, 212);
            this.buttonNotificationIcon.Controls.Add(this.redDot);
            this.buttonNotificationIcon.Cursor = Cursors.Hand;
            this.buttonNotificationIcon.FlatAppearance.BorderSize = 0;
            this.buttonNotificationIcon.FlatStyle = FlatStyle.Flat;
            this.buttonNotificationIcon.Font = new Font("Segoe UI", 20F);
            this.buttonNotificationIcon.ForeColor = Color.White;
            this.buttonNotificationIcon.Location = new Point(1200, 15);
            this.buttonNotificationIcon.Name = "buttonNotificationIcon";
            this.buttonNotificationIcon.Size = new Size(50, 50);
            this.buttonNotificationIcon.TabIndex = 6;
            this.buttonNotificationIcon.Text = "🔔";
            this.buttonNotificationIcon.UseVisualStyleBackColor = false;
            this.buttonNotificationIcon.Click += this.buttonNotificationIcon_Click;
            // 
            // redDot
            // 
            this.redDot.BackColor = Color.Red;
            this.redDot.BorderStyle = BorderStyle.FixedSingle;
            this.redDot.Location = new Point(230, 10);
            this.redDot.Name = "redDot";
            this.redDot.Size = new Size(15, 15);
            this.redDot.TabIndex = 0;
            this.redDot.Visible = false;
            // 
            // buttonProfileIcon
            // 
            this.buttonProfileIcon.BackColor = Color.FromArgb(0, 120, 212);
            this.buttonProfileIcon.Cursor = Cursors.Hand;
            this.buttonProfileIcon.FlatAppearance.BorderSize = 0;
            this.buttonProfileIcon.FlatStyle = FlatStyle.Flat;
            this.buttonProfileIcon.Font = new Font("Segoe UI", 20F);
            this.buttonProfileIcon.ForeColor = Color.White;
            this.buttonProfileIcon.Location = new Point(1260, 15);
            this.buttonProfileIcon.Name = "buttonProfileIcon";
            this.buttonProfileIcon.Size = new Size(50, 50);
            this.buttonProfileIcon.TabIndex = 7;
            this.buttonProfileIcon.Text = "👤";
            this.buttonProfileIcon.UseVisualStyleBackColor = false;
            this.buttonProfileIcon.Click += this.buttonProfileIcon_Click;
            // 
            // panelProducts
            // 
            this.panelProducts.AutoScroll = true;
            this.panelProducts.BackColor = Color.FromArgb(240, 240, 240);
            this.panelProducts.Dock = DockStyle.Fill;
            this.panelProducts.Location = new Point(0, 80);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Padding = new Padding(10);
            this.panelProducts.Size = new Size(1400, 779);
            this.panelProducts.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new ToolStripItem[] { this.statusLabelUser });
            this.statusStrip.Location = new Point(0, 859);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1400, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabelUser
            // 
            this.statusLabelUser.Name = "statusLabelUser";
            this.statusLabelUser.Size = new Size(30, 17);
            this.statusLabelUser.Text = "User";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = Properties.Resources.logo;
            this.pictureBox1.Location = new Point(0, -23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(297, 163);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 881);
            this.Controls.Add(this.panelProducts);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.Text = "CoreStore CRM";
            this.FormClosing += this.MainForm_FormClosing;
            this.Load += this.MainForm_Load;
            this.panelMenu.ResumeLayout(false);
            this.buttonNotificationIcon.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private PictureBox pictureBox1;
        private Panel redDot;
    }
}
