namespace oopProto.UserInterface.UserInput;

public class PickUpItemInput
{
    public static string PickUpItemFromRoom(Frame gameFrame)
    {
        string userInput = "";
        bool validInput = false;
        
        while (!validInput)
        {
            gameFrame.NpcWrite("Do you want to pick up a item?", "[y] for yes\n[n] for no\n> ");
            userInput = Console.ReadLine()
                        ?? throw new ArgumentException("Arguements can't be empty");
            userInput = userInput.ToLower();

            if (userInput.Equals("y") || userInput.Equals("n"))
            {
                validInput = true;
            }
            else
            {
                gameFrame.NpcWrite("Invalid input, please try again.", "Press any key to continue...");
            }
        }
        
        return userInput;
    }
}