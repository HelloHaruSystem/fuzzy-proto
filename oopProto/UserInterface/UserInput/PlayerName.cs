namespace oopProto.UserInterface.UserInput;

public class PlayerName
{

    public static string makePlayerName()
    {
        string playerName = string.Empty;
        bool validPlayerName = false;

        Console.WriteLine("What is your name?");

        while (!validPlayerName)
        {
            try
            {
                playerName = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid name, please try again.");
            }

            if (playerName.Length == 0)
            {
                Console.WriteLine("Please enter your name.");
            } else if (playerName.Length >= 16)
            {
                Console.WriteLine("Your name is too long.\nPlease try again.");
            }
            else
            {
                validPlayerName = true;
            }
        }
        
        return playerName;
    }
}