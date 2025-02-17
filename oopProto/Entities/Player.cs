using System.Text;
using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities;

public sealed class Player : Entity
{
    private  string name;
    private  Inventory playerInventory;
    private  Weapon equipedWeapon;
    private  Room currentRoom;

    public Player() : base ()
    {
        this.maxHp = 200;
        this.currentHp = this.maxHp;
        this.name = "Player";
        this.playerInventory = new Inventory();
        this.equipedWeapon = new Weapon("Wooden Sword", 5, 256, false);
        this.currentRoom = null;
    }
    
    // getters and setters
    public string Name { get => name; set => name = value; }
    public Inventory PlayerInventory { get => playerInventory; set => playerInventory = value; }
    public Weapon EquipedWeapon { get => equipedWeapon; set => equipedWeapon = value; }
    public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }
    
    // override methods
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{this.name}\n");
        sb.Append($"HP: {this.CurrentHp}/{this.MaxHp}\t wep: {this.EquipedWeapon}\n");
        sb.Append($"Current Map: {this.CurrentRoom}\n");
        sb.Append($"Room description: {this.CurrentRoom.Description}\n");
        
        return sb.ToString();
    }
}