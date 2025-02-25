using oopProto.Entities.Services;
using oopProto.UserInterface;

namespace oopProto.Entities.GameLogic;

public class Battle
{
    private Frame _gameFrame;
    private PlayerService _playerService;
    private MonsterService _monsterService;
    private Random _random;

    public Battle(Frame gameFrame, PlayerService playerService, MonsterService monsterService)
    {
        this._gameFrame = gameFrame;
        this._playerService = playerService;
        this._monsterService = monsterService;
        
        this._random = new Random();
    }
    
    public void StartBattle()
    {
            
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
    
    
}