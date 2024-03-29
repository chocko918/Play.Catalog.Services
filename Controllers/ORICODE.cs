﻿//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using Play.Catalog.Dtos;
//using System;

//namespace Play.Catalog.Controllers
//{
//    [ApiController]
//    public class ItemsController : ControllerBase
//    {
//        // private here allows other members of the same class to assess but not members from other classes
//        private static readonly List<ItemDto> items = new()
//        {
//            new ItemDto(Guid.NewGuid(), "Potion", "Restored a small amount of HP", 5, DateTimeOffset.UtcNow),
//            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
//            new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow),
//        };



//        //[HttpGet("{id}")]
//        public ActionResult<ItemDto> GetById(Guid id)
//        {
//            var item = items.Where(item => item.Id == id).SingleOrDefault();

//            if (item == null)
//            {
//                return NotFound();
//            }

//            return item;
//        }

//        [HttpPost]
//        public ActionResult<ItemDto> Post(CreateItemDto createItemDto) 
//        {
//            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
//            items.Add(item);

//            return CreatedAtAction(nameof(GetById), new {id = item.Id}, item);
//        }

//        [HttpPut("{id}")]
//        public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
//        {
//            var existingItem = items.Where(item => item.Id == id).SingleOrDefault();

//            if (existingItem == null)
//            {
//                return NotFound();
//            }

//            var updatedItem = existingItem with
//            {
//                Name = updateItemDto.Name,
//                Description = updateItemDto.Description,
//                Price = updateItemDto.Price,
//            };

//            var index = items.FindIndex(existingItem => existingItem.Id == id);
//            items[index]= updatedItem;

//            return NoContent();

//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(Guid id) 
//        {
//            var index = items.FindIndex(existingItem => existingItem.Id == id);

//            if(index < 0)
//            {
//                return NotFound();
//            }

//            items.RemoveAt(index);

//            return NoContent();
//        }
//    }
//}
