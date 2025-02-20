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
        
        TopTextPane();
        PlayerWrite("Enter Command:");
        DisplayRoomName(roomService.CurrentRoom.RoomName);
        BattleFrame();
        PrintRoomToBattleFrame(roomService.currentArtAsArray());
        DirectionPane(roomService);
        PlayerPane(playerService, roomService);
        
        
    }
        
    private void DisplayGameFrame()
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
    
    private void PlayerPane(PlayerService playerService, RoomService roomService)
    {
        string playerInfo = playerService.GetPlayer().ToString();
        string roomInfo = roomService.CurrentRoom.ToString();
        
        CleanPane(0, yEnd - 6, 5);
        
        Console.SetCursorPosition(xStart + 1, yEnd - 6);
        Console.WriteLine(oneLine);
        Console.SetCursorPosition(xStart + 2, yEnd - 5);
        Console.Write("Player Info:");
        Console.SetCursorPosition(xStart + 3, yEnd - 4);
        Console.Write(playerInfo);
        
        Console.SetCursorPosition(xStart + 3, yEnd - 1);
        Console.Write("Room description: " + roomService.CurrentRoom.Description);
    }
    
    private void DirectionPane(RoomService roomService)
    {
        string[] pathLines = roomService.CurrentRoomAvailablePath().Split("\n");
        int cursorX = xStart + (xEnd - xStart) / 2 - pathLines[3].Length / 2;
        // int cursorX = (xStart + xEnd) / 2 - 20;
        int cursorY = yEnd - 12;
        
        CleanPane(0, cursorY, 6);
        
        foreach (string line in pathLines)
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.Write(line);
            cursorY++;
        }
    }
    
    private void TopTextPane()
    {
        CleanPane(0, 1, 5);
        
        Console.SetCursorPosition(xStart + 1, yStart + 1);
        Console.Write("Commands:");
        Console.SetCursorPosition(xStart + 1, yStart + 6);
        Console.Write(oneLine);
    }
    
    private void PlayerWrite(string title)
    {
        CleanPane(0, 1, 5);
        
        Console.SetCursorPosition(xStart + 1, yStart + 1);
        Console.Write(title);
        
        Console.SetCursorPosition(xStart + 1, yStart + 6);
        
        Console.Write(oneLine);
        Console.SetCursorPosition(xStart + 2, yStart + 2);
    }

    public void NpcWrite(string title, string text)
    {
        CleanPane(0, 1, 5);
        
        string[] textLines = text.Split("\n");
        int yTop = yStart + 2;
        
        Console.SetCursorPosition(xStart + 1, yStart + 1);
        Console.Write(title);
        Console.SetCursorPosition(xStart + 1, yStart + 6);
        Console.Write(oneLine);

        foreach (string line in textLines)
        {
            Console.SetCursorPosition(xStart + 1, yTop);
            Console.Write(line);
            yTop++;
        }
        
    }
    
    private void CleanPane(int startX, int startY,  int linesDown)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        for (int i = startY; i <= startY + linesDown; i++)
        {
            Console.SetCursorPosition(startX + 1, i);
            Console.Write(oneLine);
        }
        
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private void DisplayRoomName(string roomName)
    {
        string roomInfo = "| Room: " + roomName + " |";
        int nameX = xStart + (xEnd - xStart) / 2 - roomInfo.Length / 2;
        int nameY = yStart + 7;
        
        CleanPane(0, nameY, 2);
        
        Console.SetCursorPosition(nameX, nameY);
        Console.Write(roomInfo);
        nameY++;
        nameX = 1;
        Console.SetCursorPosition(nameX, nameY);
        Console.Write(oneLine);
        
    }
    
    private void BattleFrame()
    {
        int startX = xStart + 1, endX = xEnd - 1, startY = 9, endY = yEnd - 13;
        
        Console.ForegroundColor = ConsoleColor.Green;
        
        for (int x = startX; x <= endX; x++)
        {
            Console.SetCursorPosition(x, startY);
            Console.Write('-');
            Console.SetCursorPosition(x, endY);
            Console.Write('-');
        }
        
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void PrintRoomToBattleFrame(string[] asciiArt)
    {
        int startY = 10;
        // int endX = 97; Will have use for these later! do not delete :)
        // int endY = 16;
        string[] art = asciiArt;
        int startX = xStart + (xEnd - xStart) / 2 - art[0].Length / 2;

        CleanPane(0, startY, 16);
        
        for (int i = 0; i < art.Length; i++)
        {
            Console.SetCursorPosition(startX, startY);
            Console.Write(art[i]);
            
            startY++;
        }
    }
    
}