namespace CoreStoreCRM.Forms
{
    partial class KnowledgeBaseForm
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

            // KnowledgeBaseForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 700);
            this.Name = "KnowledgeBaseForm";
            this.Text = "База знаний";
            this.Load += new EventHandler(this.KnowledgeBaseForm_Load);
            this.ResumeLayout(false);
        }
    }
}
