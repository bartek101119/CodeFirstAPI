using CodeFirstAPI_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstAPI_Test.Data
{
    // Klasa kontekstu bazy danych
    public class InvoiceContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=InvoiceDb;User Id=root;Password=root;");
        }
    }
}
