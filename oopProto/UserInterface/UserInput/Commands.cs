using System.Text;
using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;
using oopProto.Layout;
using oopProto.UserInterface;
using oopProto.UserInterface.UserInput;

namespace oopProto.Entities.GameLogic;

public class Commands
{
    public static bool SelectCommand(PlayerService playerService, RoomService roomService, Frame gameFrame)
    {
        bool validInput = false;
        bool gameNotOver = true;
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
                case "use":
                    gameFrame.ShowInventoryPane(playerService.GetPlayer().PlayerInventory);
                    UseCommand(gameFrame, playerService);
                    Console.ReadKey();
                    validInput = true;
                    break;
                case "drop":
                    gameFrame.ShowInventoryPane(playerService.GetPlayer().PlayerInventory);
                    DropCommand(gameFrame, playerService, roomService);
                    Console.ReadKey();
                    validInput = true;
                    break;
                case "search":
                    SearchCommand(roomService, gameFrame, playerService);
                    validInput = true;
                    break;
                case "save game":
                    SaveAndExitCommand(gameFrame, playerService, roomService);
                    validInput = true;
                    gameNotOver = false;
                    break;
                case "exit":
                    ExitCommand(gameFrame);
                    validInput = true;
                    gameNotOver = false;
                    break;
                default:
                    gameFrame.NpcWrite("Invalid Command!", "Please try again. Press any key to continue...");
                    Console.ReadKey();
                    validInput = true;
                    break;
            }
        }

        return gameNotOver;
    }

    private static void ShowCommands(Frame gameFrame)
    {
        StringBuilder commands = new StringBuilder();
        commands.Append("\"go north\" To go north\t \"go east\" To go east\n");
        commands.Append("\"go south\" To go south\t \"go west\" To go west\n" );
        commands.Append("\"show inventory\" To show inventory\n");
        commands.Append("Page 1/3 press any key to show next page...");
        gameFrame.NpcWrite("Enter Command:", commands.ToString());
        Console.ReadKey();
        
        commands.Clear();
        
        commands.Append("\"use\" To use an item\n");
        commands.Append("\"drop\" To drop an item in the room\n");
        commands.Append("\"search\" To Search the current room for items\n");
        commands.Append("Page 2/3 press any key to show next page...");
        gameFrame.NpcWrite("Enter Command:", commands.ToString());
        Console.ReadKey();

        commands.Clear();
        commands.Append("\"save game\" To save your current progress and exit\n");
        commands.Append("\"exit\" To exit the game without saving\n");
        commands.Append("Page 3/3\n> ");
        gameFrame.NpcWrite("Enter Command:", commands.ToString());
    }

    private static void DropCommand(Frame gameFrame, PlayerService playerService, RoomService roomService)
    {
        int userInput = ItemNumber.GetItemNumber(gameFrame) - 1;
        int inventoryLength = playerService.GetPlayer().PlayerInventory.CurrentCapacity -1;

        if (inventoryLength < 0 || userInput > inventoryLength)
        {
            gameFrame.NpcWrite("Invalid input", "Please try again. Press any key to continue...");
        }
        else
        {
            Item itemToDrop = playerService.RemoveItem(playerService.GetPlayer().PlayerInventory.Items[userInput]);
            Room roomToDropItemIn = roomService.CurrentRoom;

            roomService.AddItemToRoom(itemToDrop);
            gameFrame.NpcWrite("Dropping item...", $"You dropped {itemToDrop.Name} in {roomToDropItemIn.RoomName}\nPress any key to continue...\n> ");
        }
        
    }

    private static void SearchCommand(RoomService roomService, Frame gameFrame, PlayerService playerService)
    {
        string pickUpItem = "";
        List<Item> itemsInCurrentRoom = roomService.CurrentRoom.Items;
        StringBuilder itemsFound = new StringBuilder();

        if (itemsInCurrentRoom.Count == 0)
        {
            gameFrame.NpcWrite("by searching for items... you found....", $"nothing...\nPress any key to continue...\n> ");
            Console.ReadKey();
        }
        else
        {
            for (int i = 0; i < itemsInCurrentRoom.Count; i++)
            {
                itemsFound.Append($"{itemsInCurrentRoom[i].Name}\n");
            }
        
            gameFrame.NpcWrite("by searching for items... you found....", $"{itemsFound.ToString()}\nPress any key to continue...\n> ");
            Console.ReadKey();

            pickUpItem = PickUpItemInput.PickUpItemFromRoom(gameFrame);

            if (pickUpItem.Equals("y"))
            {
                PickUpItem(gameFrame, playerService, roomService);
            }
        }
    }

    private static void PickUpItem(Frame gameFrame, PlayerService playerService, RoomService roomService)
    {
        ItemRepository repository = new ItemRepository();
        gameFrame.ShowRoomItemsPane(roomService);
        int userInput = ItemNumber.GetItemNumber(gameFrame) - 1;
        int roomItemListLength = roomService.CurrentRoom.Items.Count;
        
        if (roomItemListLength < 0 || userInput > roomItemListLength)
        {
            gameFrame.NpcWrite("Invalid input", "Please try again. Press any key to continue...\n> ");
        }
        else
        {
            Item itemToPickUp = roomService.CurrentRoom.Items[userInput];
            playerService.AddItem(roomService.RemoveItemFromRoom(itemToPickUp));
            
            gameFrame.NpcWrite($"You picked up {itemToPickUp.Name}", "Please try again. Press any key to continue...\n> ");
            repository.DeleteItemFromRoom(itemToPickUp, roomService.CurrentRoom.RoomId);
            repository.AddItemToInventory(itemToPickUp, playerService.GetPlayer().Id);
            Console.ReadKey();
        }
    }
    
    public static void UseCommand(Frame gameFrame, PlayerService playerService)
    {
        ItemRepository repository = new ItemRepository();
        int userInput = ItemNumber.GetItemNumber(gameFrame) - 1;
        int inventoryLength = playerService.GetPlayer().PlayerInventory.CurrentCapacity -1;

        if (inventoryLength < 0 || userInput > inventoryLength)
        {
            gameFrame.NpcWrite("Invalid input", "Please try again. Press any key to continue...");
        }
        else
        {
            Item itemToUse = playerService.GetPlayer().PlayerInventory.Items[userInput];
            
            
            if (itemToUse is Potion)
            {
                Potion potionToUse = (Potion)itemToUse;
                gameFrame.NpcWrite($"You used the {potionToUse.Name}.!", $"And healed you for {potionToUse.HealingAmount}\nPress any key to continue...");
                playerService.Heal(potionToUse.HealingAmount);
                playerService.RemoveItem(potionToUse);
            } 
            else if (itemToUse is Weapon)
            {
                Weapon weaponToUse = (Weapon)itemToUse;
                gameFrame.NpcWrite($"You equipped the {weaponToUse.Name}.!", $"press any key to continue...");
                playerService.SwapWeapon(weaponToUse);
            }

            repository.DeleteItemFromInventory(itemToUse, playerService.GetPlayer().Id);
        }
    }

    private static void ExitCommand(Frame gameFrame)
    {
        gameFrame.NpcWrite("Thanks for playing!", "Exiting...\nPress any key to continue...\n> ");
        Console.ReadKey();
    }

    private static void SaveAndExitCommand(Frame gameFrame, PlayerService playerService, RoomService roomService)
    {
        PlayerRepository repository = new PlayerRepository();
        repository.SavePlayer(playerService.GetPlayer(), roomService);
        
        Console.Clear();
        Console.WriteLine("Saving your progress...");
        Thread.Sleep(1000);
        
        ExitCommand(gameFrame);
    }
}