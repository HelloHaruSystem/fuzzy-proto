using System.Runtime.CompilerServices;
using System.Text;
using oopProto.Entities.Services;
using oopProto.UserInterface;

namespace oopProto.Entities.GameLogic;

public class Commands
{
    public static void SelectCommand(PlayerService playerService, RoomService roomService, Frame gameFrame)
    {
        bool validInput = false;
        string userInput = "";
        
        gameFrame.NpcWrite("Enter Command:", "[1] to show list of commands\n> ");
        
        while (!validInput)
        {
            userInput = Console.ReadLine()
                        ?? throw new IOException();
            userInput = userInput.ToLower();
            
            switch (userInput)
            { 
                case "1":
                    ShowCommands(gameFrame);
                    break;
                case "go north":
                    roomService.MoveRoom("north");
                    validInput = true;
                    break;
                case "go east":
                    roomService.MoveRoom("east");
                    validInput = true;
                    break;
                case "go south":
                    roomService.MoveRoom("south");
                    validInput = true;
                    break;
                case "go west":
                    roomService.MoveRoom("west");
                    validInput = true;
                    break;
                case "show inventory":
                    gameFrame.ShowInventoryPane(playerService.GetPlayer().PlayerInventory);
                    SelectCommand(playerService, roomService, gameFrame);
                    validInput = true;
                    break;
                default:
                    gameFrame.NpcWrite("Invalid Command!", "Please try again. Press any key to continue...");
                    Console.ReadKey();
                    validInput = true;
                    break;
            }
            
        }
        
    }

    private static void ShowCommands(Frame gameFrame)
    {
        StringBuilder commands = new StringBuilder();
        commands.Append("\"go north\" To go north\t \"go east\" To go east\n");
        commands.Append("\"go south\" To go south\t \"go west\" To go west\n" );
        commands.Append("\"show inventory\" To show inventory\n> ");
        
        gameFrame.NpcWrite("Enter Command:", commands.ToString());
    }
    
}