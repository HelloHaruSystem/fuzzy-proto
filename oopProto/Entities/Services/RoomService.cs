using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities.Services;

public class RoomService
{
    private List<Room> rooms;
    private Room currentRoom;

    public RoomService()
    {
        rooms = new List<Room>();
        // rooms = LoadRooms();    add theres later
        //currentRoom = rooms[0];  add theres later
    }
    
    // this should be removed when the constructor is finished this is just for testing
    public void SetCurrentRoom(Room room)
    {
        currentRoom = room;
    }

    // TODO: implement
    private List<Room> LoadRooms()
    {
        throw new NotImplementedException();
    }
    
    // TODO implement
    private void AddItemToRooms()
    {
        throw new NotImplementedException();
    }
    
    public void MoveRoom(String direction)
    {
        string directionString = direction.ToLower();
        
        switch (directionString)
        {
            case "north":
                this.CurrentRoom = this.CurrentRoom.North;
                break;
            case "south":
                this.CurrentRoom = this.CurrentRoom.South;
                break;
            case "east":
                this.CurrentRoom = this.CurrentRoom.East;
                break;
            case "west":
                this.CurrentRoom = this.CurrentRoom.West;
                break;
            default:
                throw new Exception("Invalid direction");
        }
    }
    
    // getters and setters
    public List<Room> Rooms { get => rooms; set => rooms = value; }
    public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }
}