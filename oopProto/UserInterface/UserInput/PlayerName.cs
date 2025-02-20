namespace oopProto.UserInterface.UserInput;

public class PlayerName
{

    public static string MakePlayerName()
    {
        string playerName = "";
        bool validPlayerName = false;

        Console.WriteLine("What is your name?");

        while (!validPlayerName)
        {
            try
            {
                
                playerName = Console.ReadLine()
                    ?? throw new ArgumentException("Arguements can't be empty");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid name, please try again.\n" + e.Message);
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