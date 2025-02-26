using oopProto.Entities;
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
    private Monster? _chasingMonster = null;
    private int _turnCounter;
    
    private GameUi(RoomService roomService,ItemService itemService)
    {
        this._running = false;
        this._playerService = new PlayerService();
        this._roomService = roomService;
        this._itemService = itemService;
        this._gameFrame = new Frame();
        
        this._turnCounter = 0;
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
        _roomService.AddMonsterToRoom(2, new Monster(10, "Slime", 25, 2, 5, 5, 0,
            new Weapon(20, "wep test", 20, 256, false), ""));
        
        // TODO: MAKE MAIN GAME LOOP MORE NEAT ASAP PLEASE!
        while (this._running)
        {
            _gameFrame.Display(this._playerService, this._roomService);
            IsThereAChasingMonster();
            
            if (IsMonsterInRoom())
            {
                NewBattle();
            }
            
            Commands.SelectCommand(this._playerService, this._roomService, this._gameFrame);
            _turnCounter++;
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

    private bool IsMonsterInRoom()
    {
        if (this._roomService.CurrentRoom.Monster != null)
        {
            return true;
        }
        
        return false;
    }

    private void NewBattle()
    {
        Battle battle = new Battle(this._gameFrame, this._playerService, this._roomService, this._roomService.CurrentRoom.Monster)
                        ?? throw new NullReferenceException();
        this._gameFrame.NpcWrite("A Monster Has appeared!", "Press any key to engage it combat...\n> ");
        Console.ReadKey();
        
        bool fled = battle.StartBattle();
        // if player fled
        if (fled)
        {
            this._chasingMonster = this._roomService.CurrentRoom.Monster;
        }
    }

    private void IsThereAChasingMonster()
    {
        if (this._chasingMonster != null && this._turnCounter % 4 == 0)
        {
            // remove chaseMonster if already defeated
            if (this._chasingMonster.CurrentHp == 0)
            {
                this._chasingMonster = null;
            }
            // if not start battle
            else
            {
                Battle chaseBattle = new Battle(this._gameFrame, this._playerService, this._roomService, this._chasingMonster);
            
                _gameFrame.NpcWrite($" You Where chased down by {this._chasingMonster.Name}", " Engaging it in battle be ready\n" +
                    " Press any key to continue...\n> ");
                Console.ReadKey();
            
                chaseBattle.StartBattle();
            }
        }
    }
}