using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CodeFirstAPI_Test.Models;
using CodeFirstAPI_Test.Services;

namespace CodeFirstAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> GetInvoices()
        {
            var invoices = _invoiceService.GetInvoices();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public ActionResult<Invoice> GetInvoiceById(int id)
        {
            var invoice = _invoiceService.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public ActionResult<Invoice> CreateInvoice(Invoice invoice)
        {
            _invoiceService.CreateInvoice(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }
            _invoiceService.UpdateInvoice(invoice);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var invoice = _invoiceService.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            _invoiceService.DeleteInvoice(invoice);
            return NoContent();
        }
    }
}