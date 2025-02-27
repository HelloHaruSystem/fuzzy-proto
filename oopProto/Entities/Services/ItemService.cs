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

    public Weapon? GetWeapon(int weaponId)
    {
        Item weapon = this._listOfItems.Find(w => w.Id == weaponId);

        if (weapon is Weapon)
        {
            return (Weapon)weapon;
        }
        return null;
    }
    
    // getters and setters
    public List<Item> ListOfItems { get => _listOfItems; set => _listOfItems = value; }
}