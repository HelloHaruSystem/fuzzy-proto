﻿using System.Text;
using oopProto.Entities.Repositorys;
using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities.Services;

public class RoomService
{
    private List<Room> rooms;
    private Room currentRoom;

    public RoomService(List<Room> rooms)
    {
        this.rooms = rooms
            ?? new List<Room>();
        currentRoom = this.rooms.Find(r => r.RoomId == 1)
                      ?? throw new NullReferenceException("Starting room with id 1 not found!");
    }

    // TODO implement
    private void AddItemToRooms()
    {
        throw new NotImplementedException();
    }
    
    // TODO: Figure out a way to let the player know when a non existent path is chosen
    public void MoveRoom(String direction)
    {
        string directionString = direction.ToLower();
        
        switch (directionString)
        {
            case "north":
                if (this.currentRoom.NorthId == 0) return;
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.NorthId)
                    ?? throw new NullReferenceException();
                break;
            case "south":
                if (this.currentRoom.SouthId == 0) return;
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.SouthId)
                    ?? throw new NullReferenceException();
                break;
            case "east":
                if (this.currentRoom.EastId == 0) return;
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.EastId)
                    ?? throw new NullReferenceException();
                break;
            case "west":
                if (this.currentRoom.WestId == 0) return;
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.WestId)
                    ?? throw new NullReferenceException();
                break;
            default:
                throw new Exception("Invalid direction");
        }
    }

    public string CurrentRoomAvailablePath()
    {
        string northPath = "", southPath = "", eastPath = "", westPath = "";
        string currentRoomAvailablePath = "";

        if (this.currentRoom.NorthId != 0) northPath = "North-Path"; else northPath = " No-Paths ";
        if (this.currentRoom.SouthId != 0) southPath = "South-Path"; else southPath = " No-Paths ";
        if (this.currentRoom.EastId != 0) eastPath = "East-Path"; else eastPath = " No-Paths";
        if (this.currentRoom.WestId != 0) westPath = "West-Path"; else westPath = "No-Paths ";
        
        currentRoomAvailablePath = $"---------------------------------------------\n" +
                                   $"|                    \u2191                      |\n" +
                                   $"|                {northPath}                 |\n" +
                                   $"|\u2190 {westPath} ------------------- {eastPath} \u2192|\n" +
                                   $"|                {southPath}                 |\n" +
                                   $"|                    \u2193                      |\n";
        
        
        return currentRoomAvailablePath;
    }

    public string[] currentArtAsArray()
    {
        string[] asciiArtArray = this.currentRoom.AsciiArt.Split("\n");
        
        return asciiArtArray;
    }
    
    // getters and setters
    public List<Room> Rooms { get => rooms; set => rooms = value; }
    public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }
}