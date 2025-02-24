using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Services;

public class PlayerService
{
    private Player player;
    
    public PlayerService()
    {
        this.player = new Player();
    }

    public void Heal(int healAmount)
    {
        this.player.CurrentHp += healAmount;
        if (player.CurrentHp > player.MaxHp)
        {
            player.CurrentHp = player.MaxHp;
        } 
    }

    public void SwapWeapon(Weapon weaponToEquip)
    {
        AddItem(this.player.EquipedWeapon);
        RemoveItem(weaponToEquip);
        this.player.EquipedWeapon = weaponToEquip;
    }
    
    // TODO: move the Console.WriteLine() method to the ui
    public void AddItem(Item item)
    {
        if (this.player.PlayerInventory.CurrentCapacity >= this.player.PlayerInventory.MaxCapacity)
        {
            Console.WriteLine("Inventory is full");
        }
        else
        {
            this.player.PlayerInventory.Items.Add(item);
            this.player.PlayerInventory.CurrentCapacity++;
        }
    }
    
    // TODO: move the Console.WriteLine() method to the ui
    public void SwapItems(Item itemToReplace, Item newItem)
    {
        if (this.player.PlayerInventory.Items.Contains(itemToReplace))
        {
            this.player.PlayerInventory.Items.Remove(itemToReplace);
            this.player.PlayerInventory.Items.Add(newItem);
        }
        else
        {
            Console.WriteLine("Item not found");
        }
    }
    
    public Item RemoveItem(Item item)
    {
        this.player.PlayerInventory.Items.Remove(item);
        this.player.PlayerInventory.CurrentCapacity--;
        
        return item;
    }
    
    public void AddMaxCapacity(int increasedCapacity)
    {
        this.player.PlayerInventory.MaxCapacity += increasedCapacity;
    }

    public bool IsInventoryEmpty()
    {
        return this.player.PlayerInventory.CurrentCapacity == 0;
    }
    
    // getters and setters
    public Player GetPlayer() => this.player;
    
    public void SetPlayerName(String playerName)
    {
        this.player.Name = playerName;
    }
    
    
}