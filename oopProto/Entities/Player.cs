using System.Text;
using Npgsql;
using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities;

public sealed class Player : Entity
{
    // TODO: id de shouldn't be initialized here
    private int id = 1;
    private  string name;
    private  Inventory playerInventory;
    private  Weapon equipedWeapon;
   
    // TODO: rework this contractor were you set name and id this will be used later when saving and loading game
    public Player() : base ()
    {
        this.maxHp = 200;
        this.currentHp = this.maxHp;
        this.name = "Player";
        this.playerInventory = new Inventory();
        this.equipedWeapon = new Weapon(1, "Wooden Sword", 5, 256, false);
    }
    
    // getters and setters
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public Inventory PlayerInventory { get => playerInventory; set => playerInventory = value; }
    public Weapon EquipedWeapon { get => equipedWeapon; set => equipedWeapon = value; }

    
    // override methods
    public override string ToString()
    {
        return $"\t\t{this.name}\tHP: {this.CurrentHp}/{this.MaxHp}\t\twep: {this.EquipedWeapon}";
    }
}