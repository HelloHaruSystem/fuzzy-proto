using oopProto.Entities.Services;
using oopProto.UserInterface;
using oopProto.UserInterface.UserInput;

namespace oopProto.Entities.GameLogic;

public class Battle
{
    private Frame _gameFrame;
    private PlayerService _playerService;
    private Monster _monster;
    private Random _random;
    private bool _isBattleOver;

    public Battle(Frame gameFrame, PlayerService playerService, Monster monster)
    {
        this._gameFrame = gameFrame;
        this._playerService = playerService;
        this._monster = monster;
        
        this._random = new Random();
        this._isBattleOver = true;
    }
    
    public void StartBattle(Monster monster)
    {
        this._isBattleOver = false;

        while (!this._isBattleOver)
        {
            this._gameFrame.BattleStart(monster);
            BattleCommand.SelectBattleCommand(this, this._playerService, this._monster, this._gameFrame);

            if (IsMonsterDefeated())
            {
                this._gameFrame.PlayerWonBattle();
            }

            if (IsPlayerDefeated())
            {
                this._gameFrame.PlayerLostBattle();
            }
            
        }
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
        
        return cannotFleeChance <= 25;
    }

    private bool IsMonsterDefeated()
    {
        if (this._monster.CurrentHp == 0)
        {
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
}