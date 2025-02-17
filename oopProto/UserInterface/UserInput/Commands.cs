using System.Runtime.CompilerServices;
using System.Text;
using oopProto.Entities.Services;

namespace oopProto.Entities.GameLogic;

public class Commands
{
    public static void selectCommand(PlayerService playerService)
    {
        bool validInput = false;
        string userInput = Console.ReadLine().ToLower();

        Console.WriteLine("Enter command:\n[1] to show list of commands");

        while (!validInput)
        {
            switch (userInput)
            { 
                case "1":
                    showCommands();
                    break;
                case "go north":
                    playerService.moveRoom("north");
                    validInput = true;
                    break;
                case "go east":
                    playerService.moveRoom("east");
                    validInput = true;
                    break;
                case "go south":
                    playerService.moveRoom("south");
                    validInput = true;
                    break;
                case "go west":
                    playerService.moveRoom("west");
                    validInput = true;
                    break;
                case "show inventory":
                    playerService.showInventory();
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    validInput = true;
                    break;
            }
            
        }
        
    }

    private static void showCommands()
    {
        StringBuilder commands = new StringBuilder();
        commands.AppendLine("\"go north\" To go north");
        commands.AppendLine("\"go east\" To go east");
        commands.AppendLine("\"go south\" To go south");
        commands.AppendLine("\"go west\" To go west");
        commands.AppendLine("\"show inventory\" To show inventory");
        
        Console.WriteLine(commands.ToString());
    }
    
}