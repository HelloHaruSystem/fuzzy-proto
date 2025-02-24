using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public sealed class Player : Entity
{
    // TODO: id de shouldn't be initialized here
    private int _id = 1;
    private  string _name;
    private  Inventory _playerInventory;
    private  Weapon _equipedWeapon;
   
    // TODO: rework this contractor were you set name and id this will be used later when saving and loading game
    public Player()
    {
        this.maxHp = 200;
        this.currentHp = this.maxHp;
        this._name = "Player";
        this._playerInventory = new Inventory();
        this._equipedWeapon = new Weapon(1, "Wooden Sword", 5, 256, false);
    }
    
    // getters and setters
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public Inventory PlayerInventory { get => _playerInventory; set => _playerInventory = value; }
    public Weapon EquipedWeapon { get => _equipedWeapon; set => _equipedWeapon = value; }

    
    // override methods
    public override string ToString()
    {
        return $"\t\t{this._name}\tHP: {this.CurrentHp}/{this.MaxHp}\t\twep: {this.EquipedWeapon}";
    }
}