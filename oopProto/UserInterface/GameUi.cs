using System.Text;
using oopProto.Entities;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool running;
    private Player player;

    public GameUi()
    {
        this.running = false;
    }
    
    public void StartGame()
    {
        running = true;
        Console.Clear();
        this.player = StartMenu.Start();
        // this.Introduction();
        Console.Clear();
        
        Console.WriteLine(this.playerPane());

        while (this.running)
        {
            


            this.running = false;
        }
    }

    private string playerPane()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{this.player.PlayerName}\n");
        sb.Append($"HP: {player.CurrentHp}/{player.MaxHp}\t wep: {player.EquipedWeapon}\n");
        sb.Append($"Current Map: {player.CurrentRoom}\n");
        sb.Append($"Room description: {player.CurrentRoom.Description}\n");
        
        return sb.ToString();
    }

    // TODO: add Introduction method
    public void Introduction()
    {
        // print introduction
        throw new NotImplementedException();
    }
    
}
