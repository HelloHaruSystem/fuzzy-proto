﻿namespace oopProto.UserInterface;

public class Frame
{
    public static void DisplayGameFrame(int xStart, int xEnd, int yStart, int yEnd)
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
    
}