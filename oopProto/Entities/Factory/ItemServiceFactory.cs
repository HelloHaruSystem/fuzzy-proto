using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Factory;

public class ItemServiceFactory
{
    public static async Task<ItemService> CreateItemService()
    {
        ItemRepository repository = new ItemRepository();
        IEnumerable<Item> loadedItems = await repository.GetAllItems();
        List<Item> itemList = loadedItems.ToList();
        ItemService itemService = new ItemService(itemList);
        
        return itemService;
    }
}