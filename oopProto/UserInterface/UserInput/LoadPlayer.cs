using oopProto.Entities.Repositorys;

namespace oopProto.UserInterface.UserInput;

public class LoadPlayer
{
    public static async Task<int> ShowAvailablePlayers()
    {
        PlayerRepository repository = new PlayerRepository();
        IEnumerable<string> loadedPlayers = await repository.GetPlayerNameAndID();
        List<string> playerNames = loadedPlayers.ToList();

        Console.WriteLine("Select a save to load by writing the id next to the player name you wanna load\n");
        foreach (string s in playerNames)
        {
            Console.WriteLine(s);
        }
        
        return playerNames.Count;
    }

    public static async Task<int> PlayerSelection()
    {
        string userInput = "";
        int userInputAsInt = 0;
        bool validInput = false;
        int amountOfPlayers = await ShowAvailablePlayers();
        Console.Write("> ");

        while (!validInput)
        {
            if (int.TryParse(Console.ReadLine(), out userInputAsInt))
            {
                if (userInputAsInt > amountOfPlayers || userInputAsInt < 0)
                {
                    Console.Write("Please enter a number next to the player you wanna load\n> ");
                }
                else
                {
                    Console.WriteLine($"Loading player {userInputAsInt}...");
                    Thread.Sleep(700);
                    validInput = true;
                }
            }
            else
            {
                Console.Write("Please enter a valid number.\n> ");
            }
            
        }
        
        return userInputAsInt;
    }
}