﻿using oopProto.Entities.Services;
using oopProto.Layout;
using oopProto.UserInterface.UserInput;

namespace oopProto.UserInterface;

public class StartMenu
{
    
    public static void Start(PlayerService playerService, RoomService roomService)
    {
        Room startRoom = new Room("Castle Entrance", "Entrance to the castle there is a big door to the north!", null, null, null, null);
        Room secondRoom = new Room("Castle Great Hall", "Second room", null, startRoom, null, null);
        startRoom.North = secondRoom;
        roomService.Rooms.Add(startRoom);
        roomService.Rooms.Add(secondRoom);
        roomService.SetCurrentRoom(startRoom);
        
        string playerName = string.Empty;
        
        Console.WriteLine("Welcome adventurer!\n");
        playerName = PlayerName.MakePlayerName();
       
        playerService.GetPlayer().Name = playerName;
    }
    
}
