
using Invoice_Api.Repo.Modal;
using Invoice_Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Invoice_Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        // GET: InvoiceController

        public InvoiceService _InvoiceService;

        public InvoiceController(InvoiceService invoiceService )
        {
            _InvoiceService = invoiceService;
        }
      

        [HttpPost("CreateInvoice")]
        public async Task<ActionResult> PostInvoice(Invoice invoice)
        {
           bool status  =  await  _InvoiceService.Create(invoice);
            if(status)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error Creating invoice");
            }
          
        }

        [HttpGet("GetbyInvoiceNo")]
        public async Task<IActionResult> GetInvoice(string InvoiceNo) 
        {
             var data  = await _InvoiceService.Get(InvoiceNo);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var jsonData = JsonSerializer.Serialize(data , options);
            return Content(jsonData, "application/json");
           // return Ok(data);
        }
        [HttpPut("UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice(Invoice invoice)
        {
           bool status  =   await _InvoiceService.Update(invoice);
            if(status )
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error in Updating Envoice");
            }
          
        }
        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoice(string InvoiceNo)
        {
            bool status =  await _InvoiceService.Delete(InvoiceNo);
            if(status)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }


   // get: invoicecontroller/details/5
    } 
}
