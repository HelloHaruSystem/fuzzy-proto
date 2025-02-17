using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;
using oopProto.Layout;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class StartMenu
{

    
    public static void Start(PlayerService playerService)
    {
        Room startRoom = new Room("Castle Entrance", "Entrance to the castle there is a big door to the north!", null, null, null, null, new List<Item>());
        Room secondRoom = new Room("Castle Great Hall", "Second room", null, startRoom, null, null, new List<Item>());
        startRoom.North = secondRoom;
        
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.makePlayerName();
       
        playerService.GetPlayer().Name = playerName;
        playerService.GetPlayer().CurrentRoom = startRoom;
    }
    
}
