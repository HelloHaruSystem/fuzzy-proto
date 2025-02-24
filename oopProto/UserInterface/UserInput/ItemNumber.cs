namespace oopProto.UserInterface.UserInput;

public class ItemNumber
{
    public static int GetItemNumber(Frame gameFrame)
    {
        string userInput = "";
        int itemNumber = 0;
        bool validPlayerName = false;

        gameFrame.NpcWrite("Enter item number: ", "Enter the number next to the item\n> ");

        while (!validPlayerName)
        {
            userInput = Console.ReadLine()
                        ?? throw new ArgumentException("Arguments can't be empty");

            if (int.TryParse(userInput, out itemNumber))
            {
                validPlayerName = true;
            }
            else
            {
                gameFrame.NpcWrite("Invalid input: ", "please enter the number next to the item");
            }
        }
        
        return itemNumber;
    }
}