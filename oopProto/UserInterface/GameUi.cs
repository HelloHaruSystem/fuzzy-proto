using oopProto.Entities.Factory;
using oopProto.Entities.GameLogic;
using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool _running;
    private PlayerService _playerService;
    private RoomService _roomService;
    private ItemService _itemService;
    private Frame _gameFrame;
    
    private GameUi(RoomService roomService,ItemService itemService)
    {
        this._running = false;
        this._playerService = new PlayerService();
        this._roomService = roomService;
        this._itemService = itemService;
        this._gameFrame = new Frame();
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
        _running = true;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        StartMenu();
        this.Introduction();
        Console.Clear();
        
        
        // for testing
        _playerService.AddItem(new Potion(2, "Minor Healing Potion", 25));
        _playerService.AddItem(new Potion(2, "Major Healing Potion", 75));
        _playerService.AddItem(new Potion(2, "Minor Healing Potion", 25));
        _playerService.AddItem(new Weapon(5, "Golden Sword", 25, 256, false));
        
        while (this._running)
        {
            _gameFrame.Display(this._playerService, this._roomService);
            Commands.SelectCommand(this._playerService, this._roomService, this._gameFrame);

            
        }
        
        Console.Clear();
        Console.ReadLine();
    }
    
    private void StartMenu()
    {
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.MakePlayerName();
       
        _playerService.GetPlayer().Name = playerName;
        
    }
    
    private void Introduction()
    {
        Console.Clear();
        Console.WriteLine($"Welcome {this._playerService.GetPlayer().Name}!");
        Console.WriteLine($"Are you ready to explore the forgotten castle?\n");
        Console.WriteLine("If so...\nPress any key to continue...");
        
        Console.ReadKey();
    }
    
}
