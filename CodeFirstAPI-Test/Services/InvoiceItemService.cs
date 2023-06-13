using System.Collections.Generic;
using CodeFirstAPI_Test.Data;
using CodeFirstAPI_Test.Models;

namespace CodeFirstAPI_Test.Services
{
    public interface IInvoiceItemService
    {
        IEnumerable<InvoiceItem> GetInvoiceItems();
        InvoiceItem GetInvoiceItemById(int id);
        void CreateInvoiceItem(InvoiceItem invoiceItem);
        void UpdateInvoiceItem(InvoiceItem invoiceItem);
        void DeleteInvoiceItem(InvoiceItem invoiceItem);
    }
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly InvoiceContext _context;
        public InvoiceItemService(InvoiceContext context)
        {
            _context = context;
        }
        public IEnumerable<InvoiceItem> GetInvoiceItems()
        {
            return _context.InvoiceItems;
        }

        public InvoiceItem GetInvoiceItemById(int id)
        {
            return _context.InvoiceItems.Find(id);
        }

        public void CreateInvoiceItem(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Add(invoiceItem);
            _context.SaveChanges();
        }

        public void UpdateInvoiceItem(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Update(invoiceItem);
            _context.SaveChanges();
        }

        public void DeleteInvoiceItem(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Remove(invoiceItem);
            _context.SaveChanges();
        }
    }
}

