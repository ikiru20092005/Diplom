namespace CoreStoreCRM.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Address { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public string StatusName { get; set; }
        public int EmployeeId { get; set; }
        public int CurrencyId { get; set; }
    }
}
