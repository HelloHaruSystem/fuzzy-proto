namespace oopProto.ItemsAndInventory;

public abstract class Item
{
    private int id;
     protected string name;

    protected Item(string name)
    {
        this.name = name;
    }

    // TODO: Implement a proper use method
    public abstract void Use();
    
    
    // getters and setters
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }

    // generated equal methods and hash code methods
    protected bool Equals(Item other)
    {
        return name == other.name;
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
        return name.GetHashCode();
    }
}