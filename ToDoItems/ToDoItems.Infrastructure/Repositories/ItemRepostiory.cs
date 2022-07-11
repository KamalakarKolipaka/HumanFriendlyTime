using Microsoft.EntityFrameworkCore;
using ToDoItems.Core.Interfaces;
using ToDoItems.Core.Models;

namespace ToDoItems.Infrastructure.Repositories
{
    public class ItemRepostiory : IItemRepostiory
    {

        private readonly AppDBContext appDbContext;

        public ItemRepostiory(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<bool> AddItem(Item item)
        {
            var result = await appDbContext.Item.AddAsync(item);
            await appDbContext.SaveChangesAsync();
            return result != null ? true : false;
        } 
        public async Task<List<Item>> GetAllItems()
        {
            List<Item> items = await appDbContext.Item.ToListAsync();
            return items;
        }

        public async Task<Item> GetItems(int itemId)
        {
            Item item = await appDbContext.Item.Where(a => a.Id == itemId).FirstOrDefaultAsync();
            return item;
        }

        public async Task<bool> UpdateItem(Item item)
        {
            Item itemsToUpdate = await appDbContext.Item.Where(a => a.Id == item.Id).FirstOrDefaultAsync();

            if (itemsToUpdate != null)
            {
                //if(item.ItemStatus == 1)
                //    itemsToUpdate.ItemStatus = ItemStatus.Complete;  
                //else
                //    itemsToUpdate.ItemStatus = ItemStatus.Incomplete;  

                itemsToUpdate.ItemStatus = item.ItemStatus;

                var result = appDbContext.Item.Update(itemsToUpdate);
                await appDbContext.SaveChangesAsync();
                return result != null ? true : false;
            }
            return false;
        }

        public async Task<bool> DeleteItem(int itemId)
        {
            var itemToDelete = await appDbContext.Item.Where(a => a.Id == itemId).FirstOrDefaultAsync();
            var result = appDbContext.Item.Remove(itemToDelete);
            await appDbContext.SaveChangesAsync();
            return result != null ? true : false;
        }
    }
}
