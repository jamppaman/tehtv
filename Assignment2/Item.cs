using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2
{
    public enum itemTypes{sword, bow, axe}
    public class Item
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        [Range(1,99)]
        public int Level { get; set; }
       // [Range (0,2)]
        public string Type { get; set; }
        public DateTime CreationTime { get; set; }

    }
    public class NewItem
    {
        public string ItemName { get; set; }
        public string Type { get; set; }

    }
    public class ModifiedItem
    {
        public int Level { get; set; }

        public Guid ItemId{get; set;}
        public string ItemName { get; set; }
    }

        [Route("api/players/{playerId}/items")]
        public class ItemController : Controller
    {
        ItemProcessor processor;
        public ItemController(ItemProcessor proc){
            processor = proc;
        }
        [HttpGet("{id}")]
        public Task<Item> GetItem(Guid playerId, Guid itemId){
            return processor.GetItem(playerId, itemId);
        }
        [HttpGet]
        public Task<Item[]> GetAllItems(Guid playerId){
            return processor.GetAllItems(playerId);
        }
        [HttpPost]
        public Task<Item> CreateItem(Guid playerId, [FromBody]NewItem item){
            return processor.CreateItem(playerId, item);
        }
        [HttpPut("{id}")]
        public Task<Item> ModifyItem(Guid playerId, [FromBody]ModifiedItem item){
            return processor.ModifyItem(playerId, item);
        }
        [HttpDelete("{id}")]
        public Task<Item> DeleteItem(Guid playerId, Guid itemId){
            return processor.DeleteItem(playerId, itemId);
        }
    
    }
    public class ItemProcessor
    {
        IRepository repository;

        public ItemProcessor (IRepository rep){
            repository = rep;
        }

        public Task<Item> GetItem(Guid itemId, Guid playerId){
            return repository.GetItem(itemId, playerId);
        }
        public Task<Item[]> GetAllItems(Guid playerId){
            return repository.GetAllItems(playerId);
        }
        public Task<Item> CreateItem(Guid playerId, NewItem item){
            Item forward = new Item();
            forward.ItemName = item.ItemName;
            forward.CreationTime = DateTime.Now;
            forward.Type = item.Type;
            forward.Level = 0;
            forward.Id = Guid.NewGuid();
            return repository.CreateItem(playerId, forward);
        }
        public Task<Item> ModifyItem(Guid playerId, ModifiedItem item){
            var tempItem = GetItem(playerId, item.ItemId).Result;  
            tempItem.Level = item.Level;
            return repository.ModifyItem(playerId, tempItem);
        }
        public Task<Item> DeleteItem(Guid playerId, Guid itemId){
            return repository.DeleteItem(playerId, itemId);
        }
    }
}