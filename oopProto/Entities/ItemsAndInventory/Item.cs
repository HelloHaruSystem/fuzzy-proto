namespace oopProto.ItemsAndInventory;

public abstract class Item
{
     protected string itemName;

    protected Item(string name)
    {
        this.itemName = name;
    }

    // TODO: Implement a proper use method
    public abstract void Use();
    
    
    // getters and setters
    private string ItemName => this.itemName;

    // generated equal methods and hash code methods
    protected bool Equals(Item other)
    {
        return itemName == other.itemName;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Item)obj);
    }

    public override int GetHashCode()
    {
        return itemName.GetHashCode();
    }
}