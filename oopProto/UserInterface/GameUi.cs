using System.Text;
using oopProto.Entities;
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
            Console.WriteLine(this.playerPane());
            

            this.running = false;
        }
    }

    private string playerPane()
    {
        Console.WriteLine(this.playerService.GetPlayer());
    }
    
    public void Introduction()
    {
        Console.WriteLine($"Welcome {PlayerService.GetPlayer().PlayerName}!}");
        Console.WriteLine($"Are you ready to explore the forgotten castle?");
        Console.WriteLine("If so...\nPress any key to continue...");
        
        Console.ReadKey();
    }
    
}
