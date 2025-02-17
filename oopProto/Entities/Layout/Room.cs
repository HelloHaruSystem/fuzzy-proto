using oopProto.ItemsAndInventory;

namespace oopProto.Layout;

public class Room
{
    private int roomId;
    private string roomName;
    private string description;
    private Room north;
    private Room south;
    private Room east;
    private Room west;
    private List<Item> items;

    public Room(int roomId, string roomName, string description)
    {
        this.roomId = roomId;
        this.roomName = roomName;
        this.description = description;
        this.items = new List<Item>();
    }
    
    // getters and setters
    public int RoomId { get => roomId; set => roomId = value; }
    public string Description { get => description; set => description = value; }
    public Room North { get => north; set => north = value; }
    public Room South { get => south; set => south = value; }
    public Room East { get => east; set => east = value; }
    public Room West { get => west; set => west = value; }
    public List<Item> Items => items;
    
    // override methods
    public override string ToString()
    {
        return $"Room name: {this.roomName}\nRoom description: {this.description}";
    }
}