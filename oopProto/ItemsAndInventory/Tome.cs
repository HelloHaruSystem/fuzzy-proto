namespace oopProto.ItemsAndInventory;

public class Tome : Item
{
    private string magicType;
    private int usesLeft;
    private int magicDamage;
    
    public Tome(string name, string magicType) : base(name)
    {
        this.itemName = name;
        this.magicType = magicType;
        this.usesLeft = 10;
        this.magicDamage = 20;
    } 
    
    // getters and setters
    // TODO: duplicate code with weapon make tome a weapon type?
    public int Damage => this.magicDamage;
    public int UsesLeft => this.usesLeft;
}