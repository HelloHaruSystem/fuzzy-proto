using oopProto.Entities.Services;
using oopProto.Layout;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class StartMenu
{
    
    public static void Start(PlayerService playerService, RoomService roomService)
    {
        roomService.testRooms();
        Console.ReadKey();
        
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.MakePlayerName();
       
        playerService.GetPlayer().Name = playerName;
    }
    
}
