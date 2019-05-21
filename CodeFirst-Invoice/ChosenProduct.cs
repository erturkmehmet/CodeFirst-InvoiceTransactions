namespace CodeFirst_Invoice
{
    public class ChosenProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal VAT { get; set; }
    }

}