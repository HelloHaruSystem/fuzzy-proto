using oopProto.ItemsAndInventory;

namespace oopProto.Layout;

public class Room
{
    private string roomName;
    private string description;
    private Room north;
    private Room south;
    private Room east;
    private Room west;
    List<Item> items = new List<Item>();

    public Room(string roomName, string description, Room north, Room south, Room east, Room west, List<Item> items)
    {
        this.roomName = roomName;
        this.description = description;
        this.north = north;
        this.south = south;
        this.east = east;
        this.west = west;
        this.items = items;
    }

    // getters and setters
    public string Description { get => description; set => description = value; }
    public Room North { get => north; set => north = value; }
    public Room South { get => south; set => south = value; }
    public Room East { get => east; set => east = value; }
    public Room West { get => west; set => west = value; }
    public List<Item> Items => items;
    
    // override methods
    public override string ToString()
    {
        return $"{this.roomName}";
    }
}