namespace oopProto.Entities.Services;

public class PlayerService
{
    private Player player;
    
    public PlayerService()
    {
        this.player = new Player();
    }
    
    public void moveRoom(String direction)
    {
        string directionString = direction.ToLower();
        
        switch (directionString)
        {
            case "north":
                this.player.CurrentRoom = this.player.CurrentRoom.North;
                break;
            case "south":
                this.player.CurrentRoom = this.player.CurrentRoom.South;
                break;
            case "east":
                this.player.CurrentRoom = this.player.CurrentRoom.East;
                break;
            case "west":
                this.player.CurrentRoom = this.player.CurrentRoom.West;
                break;
            default:
                throw new Exception("Invalid direction");
        }
    }
    
    public Player GetPlayer() => this.player;
    
    //TODO: move to service class
    public void showInventory()
    {
        this.player.PlayerInventory.showInventory();
    }

    public void setPlayerName(String playerName)
    {
        this.player.PlayerName = playerName;
    }
}