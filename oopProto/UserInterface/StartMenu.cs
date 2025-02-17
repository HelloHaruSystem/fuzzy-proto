using oopProto.Entities.GameLogic;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class StartMenu
{

    
    public void Start()
    {
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.makePlayerName();
        CreateNewGame.CreateGame(playerName);
    }
    
}
