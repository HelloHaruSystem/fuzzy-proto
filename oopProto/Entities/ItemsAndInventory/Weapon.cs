using oopProto.Entities;

namespace oopProto.ItemsAndInventory;

public class Weapon : Item
{
    private int damage;
    private int usesLeft;
    private bool isRanged;

    public Weapon(int id, string itemName, int damage, int usesLeft, bool isRanged) : base(id, itemName)
    {
        this.id = id;
        this.name = itemName;
        this.damage = damage;
        this.usesLeft = usesLeft;
        this.isRanged = isRanged;
    }

    public override void Use(Player player)
    {
        throw new NotImplementedException();
    }

    // getters and setters
    public int Damage => this.damage;
    public int UsesLeft => this.usesLeft;
    public bool IsRanged => this.isRanged;
    
    public override string ToString()
    {
        return $"{name}: Damage: {damage}, UsesLeft: {usesLeft}";
    }
}