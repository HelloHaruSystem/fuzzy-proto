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
        LoadDirections();
        currentRoom = this.rooms.Find(r => r.RoomId == 1);
    }
    
    // test method
    public void testRooms()
    {
        foreach (Room r in rooms)
        {
            if (r.North != null)
            {
                Console.WriteLine(r.North);
            }
            if (r.South != null)
            {
                Console.WriteLine(r.South);
            }

            if (r.East != null)
            {
                Console.WriteLine(r.East);
            }

            if (r.West != null)
            {
                Console.WriteLine(r.West);
            }

            Console.WriteLine();
        }
    }
    
    // this should be removed when the constructor is finished this is just for testing
    public void SetCurrentRoom(Room room)
    {
        currentRoom = room;
    }

    public void LoadDirections()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Resources/RoomsConnection.csv");
        
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] connectionLines = lines[i].Split(',');

                SetAdjcentRooms(int.Parse(connectionLines[0]), int.Parse(connectionLines[1]), 
                    int.Parse(connectionLines[2]), int.Parse(connectionLines[3]), int.Parse(connectionLines[4]));
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error loading rooms from csv\n" + e.Message);
        }
    }

    // adds a Direction to a room
    public void SetAdjcentRooms(int roomID, int northId, int southId, int eastId, int westId)
    {
        Room room = rooms.Find(r => r.RoomId == roomID);
        
        if (northId != 0)
        {
            room.North = rooms.Find(r => r.RoomId == northId);
        }
        else
        {
            room.North = null;
        }

        if (southId != 0)
        {
            room.South = rooms.Find(r => r.RoomId == southId);
        }
        else
        {
            room.South = null;
        }

        if (eastId != 0)
        {
            room.East = rooms.Find(r => r.RoomId == eastId);
        }
        else
        {
            room.East = null;
        }

        if (westId != 0)
        {
            room.West = rooms.Find(r => r.RoomId == westId);
        }
        else
        {
            room.West = null;
        }
    }
    
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