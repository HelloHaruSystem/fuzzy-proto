using System.Text;
using oopProto.Entities;
using oopProto.Entities.GameLogic;
using oopProto.Entities.Services;

namespace oopProto.UserInterface.UserInput;

public class BattleCommand
{
    public static void SelectBattleCommand(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        bool validInput = false;
        string userInput = "";
        
        gameFrame.NpcWrite("Enter Battle Command:", "[1] to show list of commands\n> ");
        
        while (!validInput)
        {
            userInput = Console.ReadLine()
                        ?? throw new IOException();
            userInput = userInput.ToLower();
            
            switch (userInput)
            { 
                case "1":
                    ShowBattleCommands(gameFrame);
                    break;
                
                case "attack":
                    if (battle.PlayerGoesFirst(monster))
                    {
                        PlayerGoesFirst(battle, playerService, monster, gameFrame);
                    }
                    else
                    {
                        MonsterGoesFirst(battle, playerService, monster, gameFrame);
                    }
                    validInput = true;
                    gameFrame.BattlePaneUpdate(monster);
                    Console.ReadKey();
                    break;
                
                case "run":
                    if (battle.AttemptRun())
                    {
                        Run(battle, monster, gameFrame);
                    }
                    else
                    {
                        gameFrame.NpcWrite("You attempt to run from the battle...", "but failed....!\nPress any key to continue...");
                        Console.ReadKey();
                        MonsterAttack(battle, playerService, monster, gameFrame);
                    }
                    validInput = true;
                    Console.ReadKey();
                    break;
                
                case "use":
                    gameFrame.ShowInventoryPane(playerService.GetPlayer().PlayerInventory);
                    Commands.UseCommand(gameFrame, playerService);
                    Console.ReadKey();
                    gameFrame.BattlePaneUpdate(monster);
                    MonsterAttack(battle, playerService, monster, gameFrame);
                    validInput = true;
                    Console.ReadKey();
                    break;
                
                default:
                    gameFrame.NpcWrite("Invalid Command!", "Please try again. Press any key to continue...\n> ");
                    validInput = true;
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void ShowBattleCommands(Frame gameFrame)
    {
        StringBuilder commands = new StringBuilder();
        commands.Append("\"attack\" To attack\t \"run\" To run from the battle\n");
        commands.Append("\"use\" To use an item from your inventory or to equip another weapon\n> " );
       
        gameFrame.NpcWrite("Enter Command:", commands.ToString());
    }

    private static void PlayerAttack(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        // player turn
        bool missOrDodge = battle.IsMiss(monster);

        if (missOrDodge)
        {
            gameFrame.NpcWrite($" You missed your attack!", $" {monster.Name} was able to avoid your attack!\n Press any key to continue...\n> ");
        }
        else
        {
            int damage = battle.CalculateDamage(playerService.GetPlayer(), monster);
            monster.ReceiveDamage(damage);
            gameFrame.NpcWrite($" You attacked the {monster.Name}!", $" And dealt {damage} damage to the {monster.Name}!\n Press any key to continue...\n> "); 
        }
    }

    private static void MonsterAttack(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        // monster turn
        bool missOrDodge = battle.IsMiss(playerService.GetPlayer());
        
        if (missOrDodge)
        {
            gameFrame.NpcWrite(" You Dodged the attack", $" You were able to dodge the {monster.Name}'s attack!\n Press any key to continue...\n> ");
        }
        
        int damage = battle.CalculateDamage(monster, playerService.GetPlayer());
        playerService.GetPlayer().ReceiveDamage(damage);
        gameFrame.NpcWrite($" oh No {monster.Name} attacked you", $" And dealt {damage} damage to You!\n press any key to continue...\n> ");
    }

    private static void PlayerGoesFirst(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        PlayerAttack(battle, playerService, monster, gameFrame);
        Console.ReadKey();
        
        if (monster.CurrentHp != 0)
        {
            MonsterAttack(battle, playerService, monster, gameFrame);   
        }
    }

    private static void MonsterGoesFirst(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        MonsterAttack(battle, playerService, monster, gameFrame);
        Console.ReadKey();
        
        if (playerService.GetPlayer().CurrentHp != 0)
        {
            PlayerAttack(battle, playerService, monster, gameFrame);   
        }
    }

    private static void Run(Battle battle, Monster monster, Frame gameFrame)
    {
        gameFrame.NpcWrite($" You fled...", $" You successfully fled from {monster.Name}\n Press any key to continue...\n> ");
        battle.IsBattleOver = true;
        battle.FledFromBattle = true;
    }
}