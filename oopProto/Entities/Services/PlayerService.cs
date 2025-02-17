using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Services;

public class PlayerService
{
    private Player player;
    
    public PlayerService()
    {
        this.player = new Player();
    }
    
    public void MoveRoom(String direction)
    {
        string directionString = direction.ToLower();
        
        switch (directionString)
        {
            case "north":
                this.player.CurrentRoom = this.player.CurrentRoom.North;
                break;
            case "south":
                this.player.CurrentRoom = this.player.CurrentRoom.South;
                break;
            case "east":
                this.player.CurrentRoom = this.player.CurrentRoom.East;
                break;
            case "west":
                this.player.CurrentRoom = this.player.CurrentRoom.West;
                break;
            default:
                throw new Exception("Invalid direction");
        }
    }
    
    // TODO: move Console.Write() and Console.WriteLine() methods to the ui
    public void ShowInventory()
    {
        Console.WriteLine("Items:");
        for (int i = 0; i < this.player.PlayerInventory.Items.Count; i++)
        {
            if (i % 5 == 0)
            {
                Console.WriteLine();
            }

            Console.Write($"[1]: {this.player.PlayerInventory.Items[i]}\t");
        }
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
    
    public void RemoveItem(Item item)
    {
        this.player.PlayerInventory.Items.Remove(item);
        this.player.PlayerInventory.CurrentCapacity--;
    }
    
    public void AddMaxCapacity(int increasedCapacity)
    {
        this.player.PlayerInventory.MaxCapacity += increasedCapacity;
    }
    
    // getters and setters
    public Player GetPlayer() => this.player;
    
    public void SetPlayerName(String playerName)
    {
        this.player.Name = playerName;
    }
    
}