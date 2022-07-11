using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoItems.Core.Interfaces;
using ToDoItems.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoItems.API.Controllers
{
    [ServiceFilter(typeof(ExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepostiory repostiory = null;

        public ItemsController(IItemRepostiory itemRepostiory)
        {
            repostiory = itemRepostiory;

        }
        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {       
            List<Item>  items =  await repostiory.GetAllItems();
            return Ok(items);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           Item item = await repostiory.GetItems(id);
            return Ok(item);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            var result = await repostiory.AddItem(item);
            return Ok(result);
        }

        // PUT api/<ItemsController>/5
        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] Item item)
        {
            var result = await repostiory.UpdateItem(item);
            return Ok(result);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await repostiory.DeleteItem(id);
            return Ok(result);
        }
    }
}
