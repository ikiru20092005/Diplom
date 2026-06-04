namespace CoreStoreCRM.Forms
{
    partial class NotificationForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.SuspendLayout();

            // NotificationForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 500);
            this.Name = "NotificationForm";
            this.Text = "Уведомления";
            this.Load += new EventHandler(this.NotificationForm_Load);
            this.ResumeLayout(false);
        }
    }
}
