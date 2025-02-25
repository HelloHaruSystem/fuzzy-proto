using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public sealed class Player : Entity
{
    // TODO: id de shouldn't be initialized here
    private  Inventory _playerInventory;
   
    // TODO: rework this contractor were you set name and id this will be used later when saving and loading game
    public Player(int id, string name, int maxHp, int strength, int defense, int speed, int avoidance, Weapon equippedWeapon) 
        : base(id, name, maxHp, strength, defense, speed, avoidance, equippedWeapon)
    {
        this._maxHp = 200;
        this._currentHp = this._maxHp;
        this._name = "Player";
        this._playerInventory = new Inventory();
        this._equippedWeapon = new Weapon(1, "Wooden Sword", 5, 256, false);
    }
    
    // getters and setters
    public Inventory PlayerInventory { get => _playerInventory; set => _playerInventory = value; }
    
    // override methods
    public override string ToString()
    {
        return $"\t\t{this._name}\tHP: {this.CurrentHp}/{this.MaxHp}\t\twep: {this.EquippedWeapon}";
    }
}