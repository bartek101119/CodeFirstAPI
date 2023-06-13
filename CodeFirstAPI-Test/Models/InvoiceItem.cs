namespace CodeFirstAPI_Test.Models
{
    // Klasa reprezentująca pozycję na fakturze
    public class InvoiceItem
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public long InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
