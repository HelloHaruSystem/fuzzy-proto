using oopProto.Entities;
using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;

namespace oopProto.UserInterface;

public class Frame
{
    
    // for ui
    private const int X_START = 0;
    private const int X_END = 100;
    private const int Y_START = 0;
    private const int Y_END = 40;
    private const string ONE_LINE = "---------------------------------------------------------------------------------------------------";

    public Frame()
    {
        
    }

    // battle relevant methods \\
    public void BattlePaneUpdate(Monster monster)
    {
        int startY = 10;
        
        CleanPane(0, startY, 16); 
        DisplayMonsterSprite(monster); 
        DisplayPlayerSprite();
        DisplayPlayerAndBossHp(monster);
        }

    private void DisplayPlayerAndBossHp(Monster monster)
    {
        Console.SetCursorPosition(20, 11);
        Console.Write($"{monster.Name}");
        Console.SetCursorPosition(20, 12);
        Console.Write($"{monster.CurrentHp} / {monster.MaxHp}");
    }

    private void DisplayMonsterSprite(Monster monster)
    {
        string[] monsterArt = TestTest();
        int MaxLength = LongestPartOfSprite(monsterArt);
        
        int startX = 30;
        int startY = 11;

        for (int i = 0; i < monsterArt.Length; i++)
        {
            Console.SetCursorPosition(startX, startY);
            Console.Write(monsterArt[i]);

            startY++;
        }
    }

    public string[] TestTest()
    {
        string test = "\u3000\u3000\u3000\u3000\u3000\u3000\u3000 , -‐―― ､\n" +
                 "\u3000\u3000\u3000\u3000\u3000\u3000／Ｏ\u3000\u3000\u3000 \u3000 ヽ､\u3000,-、\n" +
                 "\u3000\u3000\u3000\u3000\u3000/ｒ‐,\u3000\u3000\u3000\u3000\u3000\u3000 \u3000 Ｖ\u3000l\n" +
                 "\u3000\u3000\u3000 ／/ /\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000L_ `ｰ-、\n" +
                 "\u3000\u3000 /／／, '／\u3000\u3000\u3000\u3000\u3000＼\u3000 ＼＼\u3000ヽ\n" +
                 "\u3000 /\u3000し'\u3000 \u3000\u25cf\u3000\u3000\u3000\u3000\u3000\u25cf\u3000\u3000\u3000 ヽ l \u3000ｌ\n" +
                 "\u3000ｌ\u3000\u3000\u3000\u3000\u3000\u3000\u3000 （__人_） \u3000\u3000\u3000\u3000\u3000ｌ .|\u3000 |\n" +
                 "\u3000ヽ、\u3000\u3000\u3000 \u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000 ノ /\u3000 l\n" +
                 "\u3000\u3000\u3000`ー-､＿ﾆ二二ﾆ-―=ﾆ二／ ／\n\u3000\u3000\u3000 \u3000_ノ _/\u3000\u2227\u3000l\u3000ヽ` ､＿＿_ノ\n" +
                 "\u3000\u3000\u3000 （\u3000 (/\u3000/ｌ .ｌ \u2227\u3000 iヽ、`､\n" +
                 "\u3000\u3000\u3000\u3000 )\u3000ｌ\u3000l\u3000〉' 人ヽ\u3000ｌ \u3000 ） ヽ\n" +
                 "\u3000\u3000\u3000\u3000 し'l\u3000 V\u3000入 V\u3000 ｌ\u3000 /\u3000/\n" +
                 "\u3000\u3000\u3000\u3000\u3000\u3000L_/\u3000/\u3000）ｌ\u3000 /\u3000（__/\n" +
                 "\u3000\u3000\u3000\u3000\u3000\u3000\u3000 し'\u3000 L|\u3000 ｌ\n\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000ヽ､_）";

        string[] monsterArt = test.Split("\n");
        return monsterArt;
    }

    private void DisplayPlayerSprite()
    {
        
    }

    public void PlayerWonBattle()
    {
        NpcWrite(" You won the battle!", " yayyy");
        Console.ReadKey();
    }

    // TODO: implement that the palyer can load previous save, start over or exit the game
    public void PlayerLostBattle()
    {
        NpcWrite(" You lost the battle!", " noooo");
        Console.ReadKey();
    }
    // battle relevant method end \\
    
    
    public void Display(PlayerService playerService, RoomService roomService)
    {
        Console.Clear();
        PrintRoomToBattleFrame(roomService.CurrentArtAsArray());
        
        DisplayGameFrame();
        
        TopTextPane();
        PlayerWrite("Enter Command:");
        DisplayRoomName(roomService.CurrentRoom.RoomName);
        BattleFrame();
        DirectionPane(roomService);
        PlayerPane(playerService, roomService);
    }
        
    private void DisplayGameFrame()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        
        for (int x = X_START; x <= X_END; x++)
        {
            Console.SetCursorPosition(x, Y_START);
            Console.Write('=');
            Console.SetCursorPosition(x, Y_END);
            Console.Write('=');
        }

        for (int y = Y_START; y <= Y_END; y++)
        {
            Console.SetCursorPosition(X_START, y);
            Console.Write('#');
            Console.SetCursorPosition(X_END, y);
            Console.Write('#');
        }
        
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private void PlayerPane(PlayerService playerService, RoomService roomService)
    {
        string playerInfo = playerService.GetPlayer().ToString();
        string roomInfo = roomService.CurrentRoom.ToString();
        
        CleanPane(0, Y_END - 6, 5);
        
        Console.SetCursorPosition(X_START + 1, Y_END - 6);
        Console.WriteLine(ONE_LINE);
        Console.SetCursorPosition(X_START + 2, Y_END - 5);
        Console.Write("Player Info:");
        Console.SetCursorPosition(X_START + 3, Y_END - 4);
        Console.Write(playerInfo);
        
        Console.SetCursorPosition(X_START + 3, Y_END - 1);
        Console.Write("Room description: " + roomService.CurrentRoom.Description);
    }
    
    private void DirectionPane(RoomService roomService)
    {
        string[] pathLines = roomService.CurrentRoomAvailablePath().Split("\n");
        int cursorX = X_START + (X_END - X_START) / 2 - pathLines[3].Length / 2;
        // int cursorX = (xStart + xEnd) / 2 - 20;
        int cursorY = Y_END - 12;
        
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
        
        Console.SetCursorPosition(X_START + 1, Y_START + 1);
        Console.Write("Commands:");
        Console.SetCursorPosition(X_START + 1, Y_START + 6);
        Console.Write(ONE_LINE);
    }
    
    private void PlayerWrite(string title)
    {
        CleanPane(0, 1, 5);
        
        Console.SetCursorPosition(X_START + 1, Y_START + 1);
        Console.Write(title);
        
        Console.SetCursorPosition(X_START + 1, Y_START + 6);
        
        Console.Write(ONE_LINE);
        Console.SetCursorPosition(X_START + 2, Y_START + 2);
    }

    public void NpcWrite(string title, string text)
    {
        CleanPane(0, 1, 5);
        
        string[] textLines = text.Split("\n");
        int yTop = Y_START + 2;
        
        Console.SetCursorPosition(X_START + 1, Y_START + 1);
        Console.Write(title);
        Console.SetCursorPosition(X_START + 1, Y_START + 6);
        Console.Write(ONE_LINE);

        foreach (string line in textLines)
        {
            Console.SetCursorPosition(X_START + 1, yTop);
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
            Console.Write(ONE_LINE);
        }
        
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private void DisplayRoomName(string roomName)
    {
        string roomInfo = "| Room: " + roomName + " |";
        int nameX = X_START + (X_END - X_START) / 2 - roomInfo.Length / 2;
        int nameY = Y_START + 7;
        
        CleanPane(0, nameY, 2);
        
        Console.SetCursorPosition(nameX, nameY);
        Console.Write(roomInfo);
        nameY++;
        nameX = 1;
        Console.SetCursorPosition(nameX, nameY);
        Console.Write(ONE_LINE);
        
    }
    
    private void BattleFrame()
    {
        int startX = X_START + 1, endX = X_END - 1, startY = 9, endY = Y_END - 13;
        
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
        int maxLength = LongestPartOfSprite(art);
        int startX = X_START + (X_END - X_START) / 2 - maxLength / 2;

        CleanPane(0, startY, 16);
        
        for (int i = 0; i < art.Length; i++)
        {
            Console.SetCursorPosition(startX, startY);
            Console.Write(art[i]);
            
            startY++;
        }
    }

    private int LongestPartOfSprite(string[] asciiArt)
    {
        int maxLength = asciiArt[0].Length;

        for (int i = 1; i < asciiArt.Length; i++)
        {
            if (asciiArt[i].Length > maxLength)
            {
                maxLength = asciiArt[i].Length;
            }   
        }
        
        return maxLength;
    }

    // TODO: Implement Show item pane
    public void ShowItemPane()
    {
        
    }

    public void ShowInventoryPane(Inventory inventory)
    {
        int startY = 10;
        int startX = (X_START + (X_END - X_START) / 2) - 12;
        
        List<Item> items = inventory.Items;

        CleanPane(0, startY, 16);


        if (inventory.Items.Count <= 0)
        {
            Console.SetCursorPosition(startX, startY);
            Console.Write("Inventory is Empty");
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
            
                Console.SetCursorPosition(startX, startY);
                Console.Write($"Item {i + 1, 2}: {items[i]}");
            
                startY++;
            }
        }
    }

    public void ShowRoomItemsPane(RoomService roomService)
    {
        int startY = 10;
        int startX = (X_START + (X_END - X_START) / 2) - 12;
        List<Item> items = roomService.CurrentRoom.Items;

        CleanPane(0, startY, 16);
        
        for (int i = 0; i < items.Count; i++) 
        {
            
            Console.SetCursorPosition(startX, startY);
            Console.Write($"Item {i + 1, 2}: {items[i]}");
            
            startY++;
        }
        
    }
    
}