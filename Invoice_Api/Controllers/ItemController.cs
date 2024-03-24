using Invoice_Api.Repo.Modal;
using Invoice_Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ItemController : ControllerBase
    {

        ItemService _itemService;
        bool status;

         public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost("CreateItem")]
        public async  Task<IActionResult> Create(item _item)
        {
            status  =  await _itemService.CreateItem(_item);
            if(status)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error in Creating Item");
            }
            
        }
        [HttpGet("ItemByCategory")]
        public async Task<IActionResult> ItemByCategory(string category)
        {
            var item  = await _itemService.GetItemByCategory(category);
            return Ok(item);
        }
    }
}
