//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using Play.Catalog.Dtos;
//using Play.Catalog.Repository;
//using Microsoft.AspNetCore.Components.Web.Virtualization;
//using Play.Catalog;
//using Play.Catalog.Entities;

//namespace Play.Catalog.Controllers
//{
//    [ApiController]
//    [Route("items")]
//    public class ItemsController : ControllerBase
//    {
//        //// private here allows other members of the same class to assess but not members from other classes
//        //private static readonly List<ItemDto> items = new()
//        //{
//        //    new ItemDto(Guid.NewGuid(), "Potion", "Restored a small amount of HP", 5, DateTimeOffset.UtcNow),
//        //    new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
//        //    new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow),
//        //};

//        private readonly IItemsRepository itemsRepository;

//        //injecting item repository to items controller
//        public ItemsController(IItemsRepository itemsRepository) 
//        {
//            this.itemsRepository = itemsRepository;
//        }

//        [HttpGet]
//        //get items and turn items into Dto
//        public async Task<IEnumerable<ItemDto>> Get()
//        {
//            var items = (await itemsRepository.GetAllAsync())
//                        .Select(item => item.AsDto());
//            return items;
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
//        {
//            var item = await itemsRepository.GetAsync(id);

//            if (item == null)
//            {
//                return NotFound();
//            }

//            return item.AsDto();
//        }

//        [HttpPost]
//        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto) 
//        {
//            var item = new Item
//            {
//                Name = createItemDto.Name,
//                Description = createItemDto.Description,
//                Price = createItemDto.Price,
//                CreatedDate = DateTimeOffset.UtcNow
//            };

//            await itemsRepository.CreateAsync(item);

//            return CreatedAtAction(nameof(GetByIdAsync), new {id = item.Id}, item);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
//        {
//            var exisitingItem = await itemsRepository.GetAsync(id);

//            if(exisitingItem == null)
//            {
//                return NotFound();
//            }

//            exisitingItem.Name = updateItemDto.Name;
//            exisitingItem.Description = updateItemDto.Description;
//            exisitingItem.Price = updateItemDto.Price;

//            await itemsRepository.UpdateAsync(exisitingItem);

//            return NoContent();

//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAsync(Guid id) 
//        {
//            var item = await itemsRepository.GetAsync(id);

//            if (item == null)
//            {
//                return NotFound();
//            }

//            await itemsRepository.RemoveAsync(item.Id);

//            return NoContent();
//        }
//    }
//}
