using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CodeFirstAPI_Test.Models;
using CodeFirstAPI_Test.Services;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemService _invoiceItemService;

        public InvoiceItemController(IInvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvoiceItem>> GetInvoiceItems()
        {
            var invoiceItems = _invoiceItemService.GetInvoiceItems();
            return Ok(invoiceItems);
        }

        [HttpGet("{id}")]
        public ActionResult<InvoiceItem> GetInvoiceItemById(int id)
        {
            var invoiceItem = _invoiceItemService.GetInvoiceItemById(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            return Ok(invoiceItem);
        }

        [HttpPost]
        public ActionResult<InvoiceItem> CreateInvoiceItem(InvoiceItem invoiceItem)
        {
            _invoiceItemService.CreateInvoiceItem(invoiceItem);
            return CreatedAtAction(nameof(GetInvoiceItemById), new { id = invoiceItem.Id }, invoiceItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInvoiceItem(int id, InvoiceItem invoiceItem)
        {
            if (id != invoiceItem.Id)
            {
                return BadRequest();
            }
            _invoiceItemService.UpdateInvoiceItem(invoiceItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoiceItem(int id)
        {
            var invoiceItem = _invoiceItemService.GetInvoiceItemById(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            _invoiceItemService.DeleteInvoiceItem(invoiceItem);
            return NoContent();
        }
    }
}
