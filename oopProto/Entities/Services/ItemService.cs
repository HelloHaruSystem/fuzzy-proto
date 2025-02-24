using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Services;

public class ItemService
{
    private List<Item> _listOfItems;

    // TODO: add a function in item repository to load and create a new ItemService reference RoomService if needed
    public ItemService(List<Item> loadedItems)
    {
        this._listOfItems = loadedItems
            ?? new List<Item>();
    }
    
    // getters and setters
    public List<Item> ListOfItems { get => _listOfItems; set => _listOfItems = value; }
}