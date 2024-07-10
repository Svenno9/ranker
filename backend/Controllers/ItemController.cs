using backend.DTOs;
using backend.Model;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Item>> GetAll() =>
        ItemService.GetAll();

    [HttpGet("{id:guid}")]
    public ActionResult<Item> Get(Guid id)
    {
        var item = ItemService.Get(id);

        if(item == null)
            return NotFound();

        return item;
    }

    [HttpPost]
    public IActionResult Create(CreateItemDto itemDto)
    {            
        var item = ItemService.Add(itemDto);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] Item item)
    {
        if (id != item.Id)
            return BadRequest();
           
        var existingItem = ItemService.Get(id);
        if(existingItem is null)
            return NotFound();
   
        ItemService.Update(item);           
   
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var item = ItemService.Get(id);
   
        if (item is null)
            return NotFound();
       
        ItemService.Delete(id);
   
        return NoContent();
    }
}