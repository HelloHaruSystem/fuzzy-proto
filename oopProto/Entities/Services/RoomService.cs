using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities.Services;

public class RoomService
{
    private List<Room> _rooms;
    private Room _currentRoom;

    public RoomService(List<Room> rooms)
    {
        this._rooms = rooms;
        _currentRoom = this._rooms.Find(r => r.RoomId == 1)
                      ?? throw new NullReferenceException("Starting room with id 1 not found!");
    }

    
    public void AddItemToRoom(Item item)
    {
        this._currentRoom.Items.Add(item);
    }

    public Item RemoveItemFromRoom(Item item)
    {
        this._currentRoom.Items.Remove(item);
        return item;
    }
    
    // TODO: Figure out a way to let the player know when a non existent path is chosen
    public void MoveRoom(String direction)
    {
        string directionString = direction.ToLower();
        
        switch (directionString)
        {
            case "north":
                if (this._currentRoom.NorthId == 0) return;
                this._currentRoom = this._rooms.Find(r => r.RoomId == this._currentRoom.NorthId)
                    ?? throw new NullReferenceException();
                break;
            case "south":
                if (this._currentRoom.SouthId == 0) return;
                this._currentRoom = this._rooms.Find(r => r.RoomId == this._currentRoom.SouthId)
                    ?? throw new NullReferenceException();
                break;
            case "east":
                if (this._currentRoom.EastId == 0) return;
                this._currentRoom = this._rooms.Find(r => r.RoomId == this._currentRoom.EastId)
                    ?? throw new NullReferenceException();
                break;
            case "west":
                if (this._currentRoom.WestId == 0) return;
                this._currentRoom = this._rooms.Find(r => r.RoomId == this._currentRoom.WestId)
                    ?? throw new NullReferenceException();
                break;
            default:
                throw new Exception("Invalid direction");
        }
    }

    public string CurrentRoomAvailablePath()
    {
        string northPath = "", southPath = "", eastPath = "", westPath = "";
        string currentRoomAvailablePath = "";

        if (this._currentRoom.NorthId != 0) northPath = "North-Path"; else northPath = " No-Paths ";
        if (this._currentRoom.SouthId != 0) southPath = "South-Path"; else southPath = " No-Paths ";
        if (this._currentRoom.EastId != 0) eastPath = "East-Path"; else eastPath = " No-Paths";
        if (this._currentRoom.WestId != 0) westPath = "West-Path"; else westPath = "No-Paths ";
        
        currentRoomAvailablePath = $"---------------------------------------------\n" +
                                   $"|                    \u2191                      |\n" +
                                   $"|                {northPath}                 |\n" +
                                   $"|\u2190 {westPath} ------------------- {eastPath} \u2192|\n" +
                                   $"|                {southPath}                 |\n" +
                                   $"|                    \u2193                      |\n";
        
        
        return currentRoomAvailablePath;
    }

    public string[] CurrentArtAsArray()
    {
        string[] asciiArtArray = this._currentRoom.AsciiArt.Split("\n");
        
        return asciiArtArray;
    }
    
    // getters and setters
    public List<Room> Rooms { get => _rooms; set => _rooms = value; }
    public Room CurrentRoom { get => _currentRoom; set => _currentRoom = value; }
}