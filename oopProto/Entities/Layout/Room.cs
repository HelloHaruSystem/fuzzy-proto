using oopProto.Entities;
using oopProto.ItemsAndInventory;

namespace oopProto.Layout;

public class Room
{
    private int _roomId;
    private string _roomName;
    private string _description;
    private int _northId;
    private int _southId;
    private int _eastId;
    private int _westId;
    private string _asciiArt;
    private List<Item> _items;
    private Monster? _monster = null;

    public Room(int roomId, string roomName, string description, int northId, int southId, int eastId, int westId, string asciiArt)
    {
        this._roomId = roomId;
        this._roomName = roomName;
        this._description = description;
        this._northId = northId;
        this._southId = southId;
        this._eastId = eastId;
        this._westId = westId;
        this._asciiArt = asciiArt;
        this._items = new List<Item>();
    }
    
    // getters and setters
    public int RoomId { get => _roomId; set => _roomId = value; }
    public string RoomName { get => _roomName; set => _roomName = value; }
    public string Description { get => _description; set => _description = value; }
    public int NorthId { get => _northId; set => _northId = value; }
    public int SouthId { get => _southId; set => _southId = value; }
    public int EastId { get => _eastId; set => _eastId = value; }
    public int WestId { get => _westId; set => _westId = value; }
    public string AsciiArt { get => _asciiArt; set => _asciiArt = value; }
    public Monster? Monster { get => _monster; set => _monster = value; }
    public List<Item> Items => _items;
    
    
    // override methods
    public override string ToString()
    {
        return $"Room name: {this._roomName}\nRoom description: {this._description}";
    }
}