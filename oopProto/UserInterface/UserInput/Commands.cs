namespace oopProto.Entities.GameLogic;

public class Commands
{
    public static void selectCommand(Player player)
    {
        string userInput = Console.ReadLine().ToLower();

        switch (userInput)
        {
            case "go north":
                player.moveRoom("north");
                break;
            case "go east":
                player.moveRoom("east");
                break;
            case "go south":
                player.moveRoom("south");
                break;
            case "go west":
                player.moveRoom("west");
                break;
            case "show inventory":
                player.showInventory();
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }
}