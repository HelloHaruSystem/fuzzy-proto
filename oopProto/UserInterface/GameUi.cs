using oopProto.Entities.GameLogic;
using oopProto.Entities.Services;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class GameUi
{
    private bool running;
    PlayerService playerService;
    RoomService roomService;
    
    // for ui
    const int xStart = 0;
    const int xEnd = 100;
    const int yStart = 0;
    const int yEnd = 40;
    const string oneLine =
        "---------------------------------------------------------------------------------------------------";

    public GameUi()
    {
        this.running = false;
        this.playerService = new PlayerService();
        this.roomService = new RoomService();
    }
    
    public void StartGame()
    {
        running = true;
        Console.Clear();
        StartMenu(this.playerService, this.roomService);
        this.Introduction();
        Console.Clear();
        
        while (this.running)
        {
            PlayerPane();
            Commands.SelectCommand(this.playerService, roomService);
            
            
            
            
        }
        
        Console.ReadLine();
    }

    private void PlayerPane()
    {
        string playerInfo = this.playerService.GetPlayer().ToString();
        string roomInfo = this.roomService.CurrentRoom.ToString();
        
        
        Console.SetCursorPosition(xStart + 1, yEnd - 6);
        Console.WriteLine(oneLine);
        Console.SetCursorPosition(xStart + 2, yEnd - 5);
        Console.Write("Player Info:");
        Console.SetCursorPosition(xStart + 3, yEnd - 4);
        Console.Write(playerInfo);
        Console.SetCursorPosition(xStart + 3, yEnd - 2);
        Console.Write("Room name: " + this.roomService.CurrentRoom.RoomName);
        Console.SetCursorPosition(xStart + 3, yEnd - 1);
        Console.Write("Room description: " + this.roomService.CurrentRoom.Description);
    }

    private void DirectionPane()
    {
        string[] pathLines = this.roomService.CurrentRoomAvailablePath().Split("\n");
        int cursorX = xStart + (xEnd - xStart) / 2 - pathLines[3].Length / 2;
        int cursorY = yEnd - 12;
        
        foreach (string line in pathLines)
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.Write(line);
            cursorY++;
        }


    }

    private void TopTextPane()
    {
        Console.SetCursorPosition(xStart + 1, yStart + 1);
        Console.Write("Commands:");
        Console.SetCursorPosition(xStart + 1, yStart + 6);
        Console.Write(oneLine);
    }

    public void PlayerWrite(string title)
    {
        Console.SetCursorPosition(xStart + 1, yStart + 1);
        Console.Write(title);
        Console.SetCursorPosition(xStart + 2, yStart + 2);
    }

    public void NpcWrite(string title, string text)
    {
        Console.SetCursorPosition(xStart + 1, yStart + 1);
        Console.Write(title);
        Console.SetCursorPosition(xStart + 1, yStart + 2);
        Console.Write(text);

    }
    
    private void StartMenu(PlayerService playerService, RoomService roomService)
    {
        Frame.DisplayGameFrame(xStart, xEnd, yStart, yEnd);
        PlayerPane();
        DirectionPane();
        TopTextPane();
        PlayerWrite("Enter Command:");
        Console.ReadKey();
        Console.WriteLine(roomService.CurrentRoomAvailablePath());
        Console.ReadKey();
        
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.MakePlayerName();
       
        playerService.GetPlayer().Name = playerName;
    }
    
    private void Introduction()
    {
        Console.Clear();
        Console.WriteLine($"Welcome {this.playerService.GetPlayer().Name}!");
        Console.WriteLine($"Are you ready to explore the forgotten castle?\n");
        Console.WriteLine("If so...\nPress any key to continue...");
        
        Console.ReadKey();
    }

    private void ShowPaths()
    {
        
    }
    
}
