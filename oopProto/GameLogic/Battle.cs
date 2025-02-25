using oopProto.Entities.Services;
using oopProto.UserInterface;

namespace oopProto.Entities.GameLogic;

public class Battle
{
    private Frame _gameFrame;
    private PlayerService _playerService;
    private MonsterService _monsterService;

    public Battle(Frame gameFrame, PlayerService playerService, MonsterService monsterService)
    {
        this._gameFrame = gameFrame;
        this._playerService = playerService;
        this._monsterService = monsterService;
    }
    
    public void StartBattle()
    {
            
    }

    public int CalculateDamage()
    {

        return 0;
    }
    
    
}