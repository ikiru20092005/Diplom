namespace CoreStoreCRM.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Remains { get; set; }
        public int HonestSign { get; set; }
        public string Unit { get; set; }
        public int ProductTypeId { get; set; }
    }
}
