using oopProto.Entities;

namespace oopProto.ItemsAndInventory;

public class Weapon : Item
{
    private int damage;
    private int usesLeft;
    private bool isRanged;

    public Weapon(int id, string itemName, int damage, int usesLeft, bool isRanged) : base(itemName)
    {
        this.id = id;
        this.name = itemName;
        this.damage = damage;
        this.usesLeft = usesLeft;
        this.isRanged = isRanged;
    }
    
    // getters and setters
    public int Damage => this.damage;
    public int UsesLeft => this.usesLeft;
    public bool IsRanged => this.isRanged;
    
    // override methods
    // TODO: add a proper use method
    public override void Use()
    {
        
        
        usesLeft--;
        if (usesLeft == 0)
        {
            
        }
        
        throw new NotImplementedException();
    }
    
    public override string ToString()
    {
        return $"{name}: Damage: {damage}, UsesLeft: {usesLeft}";
    }
}