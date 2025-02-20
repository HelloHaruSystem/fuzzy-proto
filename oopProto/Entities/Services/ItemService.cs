using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Services;

public class ItemService
{
    private List<Item> listOfItems;

    // TODO: add a function in item repository to load and create a new ItemService reference RoomService if needed
    public ItemService(List<Item> loadedItems)
    {
        this.listOfItems = loadedItems
            ?? new List<Item>();
    }
    
    
    
    
    
    
    // getters and setters
    public List<Item> ListOfItems { get => listOfItems; set => listOfItems = value; }
}