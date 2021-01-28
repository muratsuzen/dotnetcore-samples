using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Services
{
    public interface IItemService
    {
        List<Item> GetAll();
    }
    public class ItemService : IItemService
    {
        private List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Code = "0001", Name = "Notebook", Amount = 22, Price = 6300 },
            new Item { Id = 2, Code = "0002", Name = "Keyboard", Amount = 15, Price = 230 },
            new Item { Id = 3, Code = "0003", Name = "Mouse", Amount = 9, Price = 150 },
        };
        public List<Item> GetAll()
        {
            return _items.ToList();
        }
    }
}
