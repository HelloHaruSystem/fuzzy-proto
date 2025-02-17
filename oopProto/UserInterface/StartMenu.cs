using oopProto.Entities;
using oopProto.Entities.GameLogic;
using oopProto.ItemsAndInventory;
using oopProto.Layout;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class StartMenu
{

    
    public static Player Start()
    {
        Room startRoom = new Room("Castle Entrance", "Entrance to the castle", null, null, null, null, new List<Item>());
        Room secondRoom = new Room("Castle Great Hall", "Second room", null, startRoom, null, null, new List<Item>());
        startRoom.North = secondRoom;
        
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.makePlayerName();
        // CreateNewGame.CreateGame(playerName);
        
        return new Player(playerName, startRoom);
    }
    
}
