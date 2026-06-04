using CoreStoreCRM.DataAccess;

namespace CoreStoreCRM.Forms
{
    public partial class OrdersForm : Form
    {
        private OrderRepository orderRepo = new OrderRepository();

        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            this.Text = "Мои заказы";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(700, 400);
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = orderRepo.GetClientOrders(SessionManager.CurrentUser.UserId);

            dataGridViewOrders.DataSource = null;
            dataGridViewOrders.DataSource = orders;

            dataGridViewOrders.Columns["OrderId"].HeaderText = "ID";
            dataGridViewOrders.Columns["StartDate"].HeaderText = "Дата начала";
            dataGridViewOrders.Columns["Amount"].HeaderText = "Сумма";
            dataGridViewOrders.Columns["StatusName"].HeaderText = "Статус";
            dataGridViewOrders.Columns["Address"].HeaderText = "Адрес";
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}
