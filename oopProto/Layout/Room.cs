using oopProto.ItemsAndInventory;

namespace oopProto.Layout;

public class Room
{
    private string description;
    private Room north;
    private Room south;
    private Room east;
    private Room west;
    List<Item> items = new List<Item>();

    public Room(string description, Room north, Room south, Room east, Room west, List<Item> items)
    {
        this.description = description;
        this.north = north;
        this.south = south;
        this.east = east;
        this.west = west;
        this.items = items;
    }

    // getters and setters
    public string Description { get => description; set => description = value; }
    public Room North => north;
    public Room South => south;
    public Room East => east;
    public Room West => west;
    public List<Item> Items => items;
}