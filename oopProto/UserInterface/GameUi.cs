using oopProto.Entities.Factory;
using oopProto.Entities.GameLogic;
using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool running;
    PlayerService playerService;
    RoomService roomService;
    ItemService itemService;
    private Frame gameFrame;
    
    private GameUi(RoomService roomService,ItemService itemService)
    {
        this.running = false;
        this.playerService = new PlayerService();
        this.roomService = roomService;
        this.itemService = itemService;
        this.gameFrame = new Frame();
    }
    
    // TODO: move to its own factory class
    public static async Task<GameUi> CreateGameUi()
    {
        RoomService rService = await RoomServiceFactory.CreateRoomService();
        ItemService iService = await ItemServiceFactory.CreateItemService();
        GameUi gameUi = new GameUi(rService, iService);

        return gameUi;
    }
    
    public void StartGame()
    {
        running = true;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        StartMenu();
        this.Introduction();
        Console.Clear();
        
        
        // for testing
        playerService.AddItem(new Potion(2, "Minor Healing Potion", 25));
        playerService.AddItem(new Potion(2, "Major Healing Potion", 75));
        playerService.AddItem(new Potion(2, "Minor Healing Potion", 25));
        playerService.AddItem(new Weapon(5, "Golden Sword", 25, 256, false));
        
        while (this.running)
        {
            gameFrame.Display(this.playerService, this.roomService);
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
    
}
