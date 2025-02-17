using oopProto.Entities.Services;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool running;
    PlayerService playerService;

    public GameUi()
    {
        this.running = false;
        this.playerService = new PlayerService();
    }
    
    public void StartGame()
    {
        running = true;
        Console.Clear();
        StartMenu.Start(this.playerService);
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
