using oopProto.Entities.Services;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool running;
    PlayerService playerService;

    public GameUi()
    {
        this.running = false;
    }
    
    public void StartGame()
    {
        running = true;
        Console.Clear();
        StartMenu.Start();
        this.Introduction();
        Console.Clear();
        
        while (this.running)
        {
            playerPane();
            

            this.running = false;
        }
    }

    private void playerPane()
    {
        Console.WriteLine(this.playerService.GetPlayer());
    }
    
    private void Introduction()
    {
        Console.WriteLine($"Welcome {this.playerService.GetPlayer().PlayerName}!");
        Console.WriteLine($"Are you ready to explore the forgotten castle?");
        Console.WriteLine("If so...\nPress any key to continue...");
        
        Console.ReadKey();
    }
    
}
