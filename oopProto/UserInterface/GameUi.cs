using oopProto.Entities.Services;

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
        StartMenu.Start(this.playerService, this.roomService);
        this.Introduction();
        Console.Clear();
        
        while (this.running)
        {
            PlayerPane();
            
            
            
            
            this.running = false;
        }
        
        Console.ReadLine();
    }

    private void PlayerPane()
    {
        Console.WriteLine(this.playerService.GetPlayer());
        Console.WriteLine(this.roomService.CurrentRoom);
    }
    
    private void Introduction()
    {
        Console.Clear();
        Console.WriteLine($"Welcome {this.playerService.GetPlayer().Name}!");
        Console.WriteLine($"Are you ready to explore the forgotten castle?");
        Console.WriteLine("If so...\nPress any key to continue...");
        
        Console.ReadKey();
    }
    
}
