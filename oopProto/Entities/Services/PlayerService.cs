using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Services;

public class PlayerService
{
    private Player _player;
    
    public PlayerService(Player player)
    {
        this._player = player ?? throw new ArgumentNullException(nameof(player));
    }

    public void Heal(int healAmount)
    {
        this._player.CurrentHp += healAmount;
        if (_player.CurrentHp > _player.MaxHp)
        {
            _player.CurrentHp = _player.MaxHp;
        } 
    }

    public void SwapWeapon(Weapon weaponToEquip)
    {
        AddItem(this._player.EquippedWeapon);
        RemoveItem(weaponToEquip);
        this._player.EquippedWeapon = weaponToEquip;
    }
    
    // TODO: move the Console.WriteLine() method to the ui
    public void AddItem(Item item)
    {
        if (this._player.PlayerInventory.CurrentCapacity >= this._player.PlayerInventory.MaxCapacity)
        {
            Console.WriteLine("Inventory is full");
        }
        else
        {
            this._player.PlayerInventory.Items.Add(item);
            this._player.PlayerInventory.CurrentCapacity++;
        }
    }
    
    // TODO: move the Console.WriteLine() method to the ui
    public void SwapItems(Item itemToReplace, Item newItem)
    {
        if (this._player.PlayerInventory.Items.Contains(itemToReplace))
        {
            this._player.PlayerInventory.Items.Remove(itemToReplace);
            this._player.PlayerInventory.Items.Add(newItem);
        }
        else
        {
            Console.WriteLine("Item not found");
        }
    }
    
    public Item RemoveItem(Item item)
    {
        this._player.PlayerInventory.Items.Remove(item);
        this._player.PlayerInventory.CurrentCapacity--;
        
        return item;
    }
    
    public void AddMaxCapacity(int increasedCapacity)
    {
        this._player.PlayerInventory.MaxCapacity += increasedCapacity;
    }

    public bool IsInventoryEmpty()
    {
        return this._player.PlayerInventory.CurrentCapacity == 0;
    }
    
    // getters and setters
    public Player GetPlayer() => this._player;
    
    public void SetPlayerName(String playerName)
    {
        this._player.Name = playerName;
    }
    
    
}