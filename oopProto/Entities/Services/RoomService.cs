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
        LoadRooms();
        currentRoom = rooms[0];
    }
    
    // test method
    public void testRooms()
    {
        foreach (Room r in rooms)
        {
            Console.WriteLine(r);
        }
    }
    
    // this should be removed when the constructor is finished this is just for testing
    public void SetCurrentRoom(Room room)
    {
        currentRoom = room;
    }

    // adds a driction to a room
    public void SetAdjcentRooms(String direction, int roomId, int roomIdToAdd)
    {
        direction = direction.ToLower();
        
        // iterate over rooms where the id matches
        Room room = rooms.Find(r => r.RoomId == roomId);
        Room roomToAdd = rooms.Find(r => r.RoomId == roomIdToAdd);

        // add that room to the specified direction
        switch (direction)
        {
            case "north":
                room.North = roomToAdd;
                break;
            case "south":
                room.South = roomToAdd;
                break;
            case "east":
                room.East = roomToAdd;
                break;
            case "west":
                room.West = roomToAdd;
                break;
            default:
                throw new ArgumentException("Invalid direction");
        }
    }

    // TODO: implement
    private void LoadRooms()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Resources/Rooms.csv");

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] roomLines = lines[i].Split(',');

                this.rooms.Add(new Room(int.Parse(roomLines[0]), roomLines[1], roomLines[2]));
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error loading rooms from csv\n" + e.Message);
        }
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