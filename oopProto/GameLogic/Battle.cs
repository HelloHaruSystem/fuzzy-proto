using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.UserInterface;
using oopProto.UserInterface.UserInput;

namespace oopProto.Entities.GameLogic;

public class Battle
{
    private Frame _gameFrame;
    private PlayerService _playerService;
    private RoomService _roomService;
    private Monster _monster;
    private Random _random;
    private bool _isBattleOver;
    private bool _fledFromBattle;

    public Battle(Frame gameFrame, PlayerService playerService, RoomService roomService, Monster monster)
    {
        this._gameFrame = gameFrame;
        // add a start sequence
        this._playerService = playerService;
        this._roomService = roomService;
        this._monster = monster;
        
        this._random = new Random();
        this._isBattleOver = true;
        this._fledFromBattle = false;
    }
    
    public bool StartBattle()
    {
        this._isBattleOver = false;

        while (!this._isBattleOver)
        {
            this._gameFrame.Display(this._playerService, this._roomService);
            this._gameFrame.BattlePaneUpdate(this._monster);
            BattleCommand.SelectBattleCommand(this, this._playerService, this._monster, this._gameFrame);

            // TODO: move the NpcWrite method call to the user interface somewhere
            if (IsMonsterDefeated())
            {
                this._gameFrame.PlayerWonBattle();
                this._gameFrame.NpcWrite($" The monster Dropped {this._monster.EquippedWeapon}", " It landed somewhere in the room\n" +
                    " If you searced for it you might find it\n" +
                    " press any key to continue...");
                Console.ReadKey();
                this._roomService.AddItemToRoom(this._monster.EquippedWeapon);
                this._roomService.RemoveMonsterFromRoom(this._monster);
                this._isBattleOver = true;
            }

            if (IsPlayerDefeated())
            {
                this._gameFrame.PlayerLostBattle();
                this._isBattleOver = true;
            }
        }
        this._gameFrame.Display(this._playerService, this._roomService);
        
        return this._fledFromBattle;
    }

    public bool IsMiss(Entity defender)
    {
       return this._random.Next(1, 101) <= defender.Avoidance;
    }

    public bool PlayerGoesFirst(Monster monster)
    {
        int playerSpeedRange = this._random.Next(1, 16);
        int monsterSpeedRange = this._random.Next(1, 16);
        int playerSpeed = this._playerService.GetPlayer().Speed + playerSpeedRange;
        int monsterSpeed = monster.Speed + monsterSpeedRange;
        
        return playerSpeed > monsterSpeed;
    }

    public int CalculateDamage(Entity attacker, Entity defender)
    {
        int damageRange = this._random.Next(1, 16);
        double damage = (((double)attacker.EquippedWeapon.Damage * attacker.Strength) / defender.Defense) + damageRange;
        int damageAsInt = (int)Math.Round(damage);        

        return damageAsInt;
    }
    
    public bool AttemptRun()
    {
        int cannotFleeChance = this._random.Next(1, 101);
        
        return cannotFleeChance >= 25;
    }

    private bool IsMonsterDefeated()
    {
        if (this._monster.CurrentHp == 0)
        {
            MonsterRepository repository = new MonsterRepository();
            repository.DeleteMonsterFromRoom(this._monster);
            return true;
        }
        return false;
    }
    
    private bool IsPlayerDefeated()
    {
        if (this._playerService.GetPlayer().CurrentHp == 0)
        {
            return true;
        }
        return false;
    }
    
    // getters and setters
    public bool IsBattleOver { get => _isBattleOver; set => _isBattleOver = value; }
    public bool FledFromBattle { get => _fledFromBattle; set => _fledFromBattle = value; }
}