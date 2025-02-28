using oopProto.Entities;

namespace oopProto.ItemsAndInventory;

public abstract class Item
{
    protected int id;
    protected string name;
    private int _roomId;

    protected Item(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public abstract void Use(Player player);
    
    // getters and setters
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int RoomId { get => _roomId; set => _roomId = value; }

    // generated equal methods and hash code methods
    public override string ToString()
    {
        return this.name;
    }
    
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