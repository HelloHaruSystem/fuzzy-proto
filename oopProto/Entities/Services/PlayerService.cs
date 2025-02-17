namespace oopProto.Entities.Services;

public class PlayerService
{
    private Player player;
    
    public PlayerService()
    {
        this.player = new Player();
    }
    
    public void MoveRoom(String direction)
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
    
    //TODO: move to service class
    public void ShowInventory()
    {
        this.player.PlayerInventory.ShowInventory();
    }
    
    // getters and setters
    public Player GetPlayer() => this.player;
    
    public void SetPlayerName(String playerName)
    {
        this.player.Name = playerName;
    }
    
}