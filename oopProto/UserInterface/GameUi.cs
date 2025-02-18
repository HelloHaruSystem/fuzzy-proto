using oopProto.Entities.GameLogic;
using oopProto.Entities.Services;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool running;
    PlayerService playerService;
    RoomService roomService;
    private Frame gameFrame;
    
    public GameUi()
    {
        this.running = false;
        this.playerService = new PlayerService();
        this.roomService = new RoomService();
        this.gameFrame = new Frame();
    }
    
    public void StartGame()
    {
        running = true;
        Console.Clear();
        StartMenu();
        this.Introduction();
        Console.Clear();
        
        while (this.running)
        {
            gameFrame.Display(this.playerService, roomService);
            Commands.SelectCommand(this.playerService, this.roomService, this.gameFrame);



        }
        
        Console.Clear();
        Console.ReadLine();
    }
    
    private void StartMenu()
    {
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
