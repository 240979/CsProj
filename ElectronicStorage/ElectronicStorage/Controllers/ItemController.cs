using ElectronicStorage.DTOs;
using ElectronicStorage.Mapping;
using ElectronicStorage.Persistence.Models;
using ElectronicStorage.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly EfCoreItemRepository _repository;
        private readonly ItemMapper _mapper;

        public ItemController(EfCoreItemRepository repository, ItemMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            return await _repository.GetAll();
        }

        // GET: api/Item/5 //[FromRoute]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Item>> GetItem( Guid id)
        {
            var item = await _repository.Get(id);
            if (item == null)
                return NotFound();
            return item;
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutItem([FromRoute] Guid id, [FromBody] ItemDto newItem)
        {
            var item = await _repository.Get(id);
            if (item is null)
                return NotFound(newItem);
            item = _mapper.MapItemDtoToItem(item, newItem);
            await _repository.Update(item);
            return NoContent();
        }

        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem([FromBody] Item item)
        {
            await _repository.Add(item);

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid id)
        {
            var item = await _repository.Get(id);
            if (item == null)
                return NotFound();
            await _repository.Delete(id);
            return NoContent();
        }
    }
}