using oopProto.Entities.GameLogic;
using oopProto.Entities.Services;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool running;
    PlayerService playerService;
    RoomService roomService;

    public GameUi()
    {
        this.running = false;
        this.playerService = new PlayerService();
        this.roomService = new RoomService();
    }
    
    public void StartGame()
    {
        running = true;
        Console.Clear();
        StartMenu(this.playerService, this.roomService);
        this.Introduction();
        Console.Clear();
        
        while (this.running)
        {
            PlayerPane();
            Commands.SelectCommand(this.playerService, roomService);
            
            
            
            
        }
        
        Console.ReadLine();
    }

    private void PlayerPane()
    {
        Console.WriteLine(this.playerService.GetPlayer());
        Console.WriteLine(this.roomService.CurrentRoom);
    }
    
    private void StartMenu(PlayerService playerService, RoomService roomService)
    {
        //roomService.testRooms();
        //Console.ReadKey();
        Console.WriteLine(roomService.CurrentRoomAvailablePath());
        Console.ReadKey();
        
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.MakePlayerName();
       
        playerService.GetPlayer().Name = playerName;
    }
    
    private void Introduction()
    {
        Console.Clear();
        Console.WriteLine($"Welcome {this.playerService.GetPlayer().Name}!");
        Console.WriteLine($"Are you ready to explore the forgotten castle?\n");
        Console.WriteLine("If so...\nPress any key to continue...");
        
        Console.ReadKey();
    }

    private void ShowPaths()
    {
        
    }
    
}
