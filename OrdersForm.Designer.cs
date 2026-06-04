namespace CoreStoreCRM.Forms
{
    partial class OrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewOrders;
        private Button buttonRefresh;
        private Label labelOrders;

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
            this.dataGridViewOrders = new DataGridView();
            this.buttonRefresh = new Button();
            this.labelOrders = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();

            // labelOrders
            this.labelOrders.AutoSize = true;
            this.labelOrders.Location = new Point(10, 10);
            this.labelOrders.Name = "labelOrders";
            this.labelOrders.Size = new Size(49, 15);
            this.labelOrders.TabIndex = 0;
            this.labelOrders.Text = "Заказы:";

            // dataGridViewOrders
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new Point(10, 30);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new Size(650, 300);
            this.dataGridViewOrders.TabIndex = 1;

            // buttonRefresh
            this.buttonRefresh.Location = new Point(10, 350);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new Size(100, 30);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);

            // OrdersForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(672, 390);
            this.Controls.Add(this.labelOrders);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.buttonRefresh);
            this.Name = "OrdersForm";
            this.Text = "Заказы";
            this.Load += new EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
