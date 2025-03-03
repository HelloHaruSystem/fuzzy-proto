using oopProto.Entities;
using oopProto.Entities.GameLogic;
using oopProto.Entities.Services;
namespace oopProto.UserInterface;

public class GameUi
{
    private bool _running;
    private PlayerService _playerService;
    private RoomService _roomService;
    private ItemService _itemService;
    private MonsterService _monsterService;
    private Frame _gameFrame;
    private Monster? _chasingMonster = null;
    private int _turnCounter;
    
    public GameUi(RoomService roomService,ItemService itemService, MonsterService monsterService, PlayerService playerService)
    {
        this._running = false;
        this._turnCounter = 0;
        this._gameFrame = new Frame();
        
        this._roomService = roomService;
        this._itemService = itemService;
        this._monsterService = monsterService;
        this._playerService = playerService;
    }
    
    public void StartGame()
    {
        _running = true;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        
        this.Introduction();
        Console.Clear();
        
        // TODO: MAKE MAIN GAME LOOP MORE NEAT ASAP PLEASE!
        while (this._running)
        {
            _gameFrame.Display(this._playerService, this._roomService);
            IsThereAChasingMonster();
            
            if (IsMonsterInRoom())
            {
                NewBattle();
            }
            
            this._running = Commands.SelectCommand(this._playerService, this._roomService, this._gameFrame);
            _turnCounter++;
        }
        
        Console.Clear();
    }
    
    private void Introduction()
    {
        Console.Clear();
        Console.WriteLine($"Welcome {this._playerService.GetPlayer().Name}!");
        Console.WriteLine($"Are you ready to explore the forgotten castle?\n");
        Console.Write("If so...\nPress any key to continue...\n> ");
        
        Console.ReadKey();
    }

    public void CloseGame()
    {
        this._running = false;
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