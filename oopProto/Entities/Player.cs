using System.Collections.Generic;
using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public class Player : Entity
{
    private string playerName;
    private Inventory playerInventory;
    private Weapon equipedWeapon;

    public Player(string name) : base ()
    {
        this.maxHp = 200;
        this.playerName = name;
        this.playerInventory = new Inventory();
        this.equipedWeapon = new Weapon("Wooden Sword", 5, 256, false);
    }

    public void showInventory()
    {
        this.playerInventory.showInventory();
    }
    
    // getters and setters
    public string PlayerName { get => playerName; set => playerName = value; }
}