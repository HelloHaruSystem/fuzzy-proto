using oopProto.Entities;
using oopProto.Entities.Repositorys;
using oopProto.ItemsAndInventory;

namespace oopProto.UserInterface.UserInput;

public class CreateNewPlayer
{
    public static Player CreatenewPlayer()
    {
        PlayerRepository pRepository = new PlayerRepository();
        ItemRepository itemRepository = new ItemRepository();
        bool statsReroll = true;
        Player player;
        
        int playerId = 0;
        string playerName = string.Empty;
        
        // stats index 0 = hp, 1 = strength, 2 = defense 3 = speed, 4 = avoidance
        int[] stats = new int[5];
        int currentHp = 0;
        // weapons and inventory
        Weapon startingWeapon = new Weapon(1, "Wooden Sword", 10, 256, false);
        Inventory inventory = new Inventory();
        // adding starting potion to the inventory
        Potion minorPotion = new Potion(2, "Minor Healing Potion", 25);
        inventory.Items.Add(minorPotion);
        
        // id
        playerId = PlayerRepository.GetMaxId() + 1;
        
        // name 
        Console.Clear();
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.MakePlayerName();
        
        // stats
        while (statsReroll)
        {
            stats = RollStats();

            Console.WriteLine("\nRolling your stats!");
            Console.WriteLine("Your stats:");
            Console.WriteLine($"HP:           {stats[0], 3}");
            Console.WriteLine($"Strength:     {stats[1], 3}");
            Console.WriteLine($"Defense:      {stats[2], 3}");
            Console.WriteLine($"Speed:        {stats[3], 3}");
            Console.WriteLine($"Avoidance:    {stats[4], 3}\n");

            Console.Write("Do you want to reroll or go with thee stats?\n" +
                              "[1] to keep stats\n" +
                              "[2] to reroll\n> ");
            
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("\nKeepings stats...");
                    statsReroll = false;
                    break;
                case "2":
                    Console.WriteLine("\nRerolling stats...");
                    break;
                default:
                    Console.WriteLine("\nInvalid input. rerolling stats!");
                    break;
            }
            
            currentHp = stats[0];
        }
        
        player = new Player(playerId, playerName, stats[0], stats[1], stats[2], stats[3], stats[4], startingWeapon, currentHp);
        player.PlayerInventory = inventory;
        
        pRepository.CreatePlayer(player);
        itemRepository.AddItemToInventory(minorPotion, player.Id);
        
        return player;
    }

    public static int[] RollStats()
    {
        Random random = new Random();
        int[] stats = new int[5];
        
        stats[0] = random.Next(150, 226);
        stats[1] = random.Next(1, 11);
        stats[2] = random.Next(1, 11);
        stats[3] = random.Next(1, 6);
        stats[4] = random.Next(1, 6);
        
        return stats;
    }
}