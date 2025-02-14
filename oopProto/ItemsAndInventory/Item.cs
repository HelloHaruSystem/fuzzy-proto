namespace oopProto.ItemsAndInventory;

public abstract class Item
{
     protected string itemName;

    protected Item(string name)
    {
        this.itemName = name;
    }

    // TODO: Implement a proper use method
    protected void use()
    {
        
    }
    
    // getters and setters
    private string ItemName => this.itemName;
}