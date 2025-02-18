using System.Text;
using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities;

public sealed class Player : Entity
{
    private  string name;
    private  Inventory playerInventory;
    private  Weapon equipedWeapon;
   
    public Player() : base ()
    {
        this.maxHp = 200;
        this.currentHp = this.maxHp;
        this.name = "Player";
        this.playerInventory = new Inventory();
        this.equipedWeapon = new Weapon("Wooden Sword", 5, 256, false);
    }
    
    // getters and setters
    public string Name { get => name; set => name = value; }
    public Inventory PlayerInventory { get => playerInventory; set => playerInventory = value; }
    public Weapon EquipedWeapon { get => equipedWeapon; set => equipedWeapon = value; }

    
    // override methods
    public override string ToString()
    {
        return $"\t\t{this.name}\tHP: {this.CurrentHp}/{this.MaxHp}\t\twep: {this.EquipedWeapon}";
    }
}