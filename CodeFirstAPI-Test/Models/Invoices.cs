namespace CodeFirstAPI_Test.Models
{
    // Klasa reprezentująca fakturę
    public class Invoice
    {
        public long Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
