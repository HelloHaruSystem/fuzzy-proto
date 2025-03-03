using oopProto.Entities.Factory;

namespace oopProto.UserInterface;

public class LoadOrNew
{
    public static async Task<GameUi> StartNewOrLoad()
    {
        GameUi? ui = null;
        string userInput = "";
        bool validInput = false;

        Console.Clear();
        Console.WriteLine("Welcome to the Oop game!\nDo you want to load an existing game?\nOr start a new game?");

        while (!validInput)
        {
            Console.WriteLine("Enter [1] to start a new game");
            Console.Write("Enter [2] to load an existing game\n> ");
            userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "1":
                    ui = await GameUiFactory.CreateGameUiFromScratch();
                    validInput = true;
                    break;
                case "2":
                    ui = await GameUiFactory.CreateGameUiFromSave();
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.\n> ");
                    break;
            }
        }

        return ui;
    }
}