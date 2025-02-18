using oopProto.Entities.Services;

namespace oopProto.UserInterface;

public class Frame
{
    
    // for ui
    const int xStart = 0;
    const int xEnd = 100;
    const int yStart = 0;
    const int yEnd = 40;
    const string oneLine = "---------------------------------------------------------------------------------------------------";

    public Frame()
    {
        
    }

    public void Display(PlayerService playerService, RoomService roomService)
    {
        DisplayGameFrame();
        PlayerPane(playerService, roomService);
        DirectionPane(roomService);
        TopTextPane();
        PlayerWrite("Enter Command:");
    }
        
    public void DisplayGameFrame()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        
        for (int x = xStart; x <= xEnd; x++)
        {
            Console.SetCursorPosition(x, yStart);
            Console.Write('=');
            Console.SetCursorPosition(x, yEnd);
            Console.Write('=');
        }

        for (int y = yStart; y <= yEnd; y++)
        {
            Console.SetCursorPosition(xStart, y);
            Console.Write('#');
            Console.SetCursorPosition(xEnd, y);
            Console.Write('#');
        }
        
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    public void PlayerPane(PlayerService playerService, RoomService roomService)
    {
        string playerInfo = playerService.GetPlayer().ToString();
        string roomInfo = roomService.CurrentRoom.ToString();
        
        
        Console.SetCursorPosition(xStart + 1, yEnd - 6);
        Console.WriteLine(oneLine);
        Console.SetCursorPosition(xStart + 2, yEnd - 5);
        Console.Write("Player Info:");
        Console.SetCursorPosition(xStart + 3, yEnd - 4);
        Console.Write(playerInfo);
        Console.SetCursorPosition(xStart + 3, yEnd - 2);
        Console.Write("Room name: " + roomService.CurrentRoom.RoomName);
        Console.SetCursorPosition(xStart + 3, yEnd - 1);
        Console.Write("Room description: " + roomService.CurrentRoom.Description);
    }
    
    public void DirectionPane(RoomService roomService)
    {
        string[] pathLines = roomService.CurrentRoomAvailablePath().Split("\n");
        int cursorX = xStart + (xEnd - xStart) / 2 - pathLines[3].Length / 2;
        int cursorY = yEnd - 12;
        
        foreach (string line in pathLines)
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.Write(line);
            cursorY++;
        }
    }
    
    public void TopTextPane()
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
    
}