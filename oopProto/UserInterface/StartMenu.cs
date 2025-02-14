using oopProto.Entities.GameLogic;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class StartMenu
{

    // TODO: implement the start of the ui
    public void Start()
    {
        throw new NotImplementedException();
    }

    public void NewGame()
    {
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.makePlayerName();
        CreateNewGame.CreateGame(playerName);
    }
    
}
