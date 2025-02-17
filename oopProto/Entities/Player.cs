using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities;

public class Player : Entity
{
    private string playerName;
    private Inventory playerInventory;
    private Weapon equipedWeapon;
    private Room currentRoom;

    public Player(string name, Room startRoom) : base ()
    {
        this.maxHp = 200;
        this.currentHp = this.maxHp;
        this.playerName = name;
        this.playerInventory = new Inventory();
        this.equipedWeapon = new Weapon("Wooden Sword", 5, 256, false);
        this.currentRoom = startRoom;
    }

    public void showInventory()
    {
        this.playerInventory.showInventory();
    }

    public void moveRoom(String direction)
    {
        string directionString = direction.ToLower();
        
        switch (directionString)
        {
            case "north":
                this.currentRoom = currentRoom.North;
                break;
            case "south":
                this.currentRoom = currentRoom.South;
                break;
            case "east":
                this.currentRoom = currentRoom.East;
                break;
            case "west":
                this.currentRoom = currentRoom.West;
                break;
            default:
                throw new Exception("Invalid direction");
        }
    }
    
    // getters and setters
    public string PlayerName { get => playerName; set => playerName = value; }
    public Inventory PlayerInventory { get => playerInventory; set => playerInventory = value; }
    public Weapon EquipedWeapon { get => equipedWeapon; set => equipedWeapon = value; }
    public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }
}