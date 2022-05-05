using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestExApp.Models;
using TestExApp.Models.Dtos;
using TestExApp.Services;

namespace TestExApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<List<Item>> List()
        {
            return await _itemService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> SaveItems([FromBody] List<Item> items)
        {
            await _itemService.SaveItems(items);
            return Ok();
        }
    }
}
