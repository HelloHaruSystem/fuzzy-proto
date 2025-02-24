using oopProto.Entities;

namespace oopProto.ItemsAndInventory;

public class Weapon : Item
{
    private int _damage;
    private int _usesLeft;
    private bool _isRanged;

    public Weapon(int id, string itemName, int damage, int usesLeft, bool isRanged) : base(id, itemName)
    {
        this.id = id;
        this.name = itemName;
        this._damage = damage;
        this._usesLeft = usesLeft;
        this._isRanged = isRanged;
    }

    public override void Use(Player player)
    {
        throw new NotImplementedException();
    }

    // getters and setters
    public int Damage => this._damage;
    public int UsesLeft => this._usesLeft;
    public bool IsRanged => this._isRanged;
    
    public override string ToString()
    {
        return $"{name}: Damage: {_damage}, UsesLeft: {_usesLeft}";
    }
}