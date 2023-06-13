using System.Collections.Generic;
using CodeFirstAPI_Test.Data;
using CodeFirstAPI_Test.Models;

namespace CodeFirstAPI_Test.Services
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetInvoices();
        Invoice GetInvoiceById(int id);
        void CreateInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceContext _context;
        public InvoiceService(InvoiceContext context)
        {
            _context = context;
        }
        public IEnumerable<Invoice> GetInvoices()
        {
            return _context.Invoices;
        }

        public Invoice GetInvoiceById(int id)
        {
            return _context.Invoices.Find(id);
        }

        public void CreateInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            _context.SaveChanges();
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
        }
    }
}

