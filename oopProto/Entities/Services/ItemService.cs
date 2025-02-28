using oopProto.Entities.Repositorys;
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

    public Item? GetItemCopy(int itemId)
    {
        Item item = this._listOfItems.Find(i => i.Id == itemId) 
            ?? throw new KeyNotFoundException();
        

        if (item is Weapon)
        {
            Weapon itemToCopyFrom = (Weapon)item;
            Weapon copyItem = new Weapon(itemToCopyFrom.Id, itemToCopyFrom.Name, itemToCopyFrom.Damage,
                itemToCopyFrom.UsesLeft, itemToCopyFrom.IsRanged);
            
            return copyItem;
        } 
        
        if (item is Potion)
        {
            Potion itemToCopyFrom = (Potion)item;
            Potion copyItem = new Potion(itemToCopyFrom.Id, itemToCopyFrom.Name, itemToCopyFrom.HealingAmount);
            
            return copyItem;
        }

        return null;
    }
    
    // getters and setters
    public List<Item> ListOfItems { get => _listOfItems; set => _listOfItems = value; }
}