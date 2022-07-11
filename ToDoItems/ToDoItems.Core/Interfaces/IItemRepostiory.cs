using ToDoItems.Core.Models;

namespace ToDoItems.Core.Interfaces
{
    public interface IItemRepostiory
    {
        Task<bool> AddItem(Item item);
        Task<Item> GetItems(int itemId);
        Task<List<Item>> GetAllItems();
        Task<bool> UpdateItem(Item item);
        Task<bool> DeleteItem(int itemId);       

    }
}
