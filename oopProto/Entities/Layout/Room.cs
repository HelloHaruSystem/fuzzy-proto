using oopProto.ItemsAndInventory;

namespace oopProto.Layout;

public class Room
{
    private int roomId;
    private string roomName;
    private string description;
    private int northId;
    private int southId;
    private int eastId;
    private int westId;
    private List<Item> items;

    public Room(int roomId, string roomName, string description, int northId, int southId, int eastId, int westId)
    {
        this.roomId = roomId;
        this.roomName = roomName;
        this.description = description;
        this.items = new List<Item>();
        this.northId = northId;
        this.southId = southId;
        this.eastId = eastId;
        this.westId = westId;
    }
    
    // getters and setters
    public int RoomId { get => roomId; set => roomId = value; }
    public string RoomName { get => roomName; set => roomName = value; }
    public string Description { get => description; set => description = value; }
    public int NorthId { get => northId; set => northId = value; }
    public int SouthId { get => southId; set => southId = value; }
    public int EastId { get => eastId; set => eastId = value; }
    public int WestId { get => westId; set => westId = value; }
    public List<Item> Items => items;
    
    // override methods
    public override string ToString()
    {
        return $"Room name: {this.roomName}\nRoom description: {this.description}";
    }
}