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
        
        gameFrame.NpcWrite("Enter Command:", "[1] to show list of commands\n> ");
        
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
                    break;
                case "run":
                    if (battle.AttemptRun())
                    {
                        Run(battle, monster, gameFrame);
                    }
                    else
                    {
                        gameFrame.NpcWrite("You attempt to run from the battle...", "but failed....!");
                    }
                    validInput = true;
                    break;
                case "use":
                    Commands.UseCommand(gameFrame, playerService);
                    MonsterAttack(battle, playerService, monster, gameFrame);
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

    private static void ShowBattleCommands(Frame gameFrame)
    {
        StringBuilder commands = new StringBuilder();
        commands.Append("\"attack\" To attack\t \"run\" To run from the battle\n");
        commands.Append("\"use\" To use an item from your inventory or to equip another weapon\n" );
       
        gameFrame.NpcWrite("Enter Command:", commands.ToString());
        Console.ReadKey();
    }

    private static void PlayerAttack(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        // player turn
        bool missOrDodge = battle.IsMiss(monster);

        if (missOrDodge)
        {
            gameFrame.NpcWrite($"You missed your attack!", $"{monster.Name} was able to avoid your attack!");
        }
        else
        {
            int damage = battle.CalculateDamage(playerService.GetPlayer(), monster);
            monster.ReceiveDamage(damage);
            gameFrame.NpcWrite($"You attacked the {monster.Name}!", $"And dealt {damage} damage to the {monster.Name}!"); 
        }
    }

    private static void MonsterAttack(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        // monster turn
        bool missOrDodge = battle.IsMiss(playerService.GetPlayer());
        
        if (missOrDodge)
        {
            gameFrame.NpcWrite("You Dodged the attack", $"You were able to dodge the {monster.Name}'s attack!");
        }
        
        int damage = battle.CalculateDamage(monster, playerService.GetPlayer());
        playerService.GetPlayer().ReceiveDamage(damage);
        gameFrame.NpcWrite($"oh No {monster.Name}", $"And dealt {damage} damage to You!");
    }

    private static void PlayerGoesFirst(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        PlayerAttack(battle, playerService, monster, gameFrame);
        if (monster.CurrentHp != 0)
        {
            MonsterAttack(battle, playerService, monster, gameFrame);   
        }
    }

    private static void MonsterGoesFirst(Battle battle, PlayerService playerService, Monster monster, Frame gameFrame)
    {
        MonsterAttack(battle, playerService, monster, gameFrame);
        if (playerService.GetPlayer().CurrentHp != 0)
        {
            PlayerAttack(battle, playerService, monster, gameFrame);   
        }
    }

    private static void Run(Battle battle, Monster monster, Frame gameFrame)
    {
        gameFrame.NpcWrite($"You fled...", $"You successfully fled from {monster.Name}");
        battle.IsBattleOver = true;
    }
}