﻿using System.Text;
using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto.Entities.Services;

public class RoomService
{
    private List<Room> rooms;
    private Room currentRoom;

    public RoomService()
    {
        rooms = new List<Room>();
        LoadRooms();
        currentRoom = this.rooms.Find(r => r.RoomId == 1);
    }
    
    // test method
    public void testRooms()
    {
        foreach (Room r in this.rooms)
        {
            Console.Write(r.RoomId + " ");
            Console.WriteLine($"North: {r.NorthId} South: {r.SouthId} East: {r.EastId} West: {r.WestId}");
        }
    }
    
    private void LoadRooms()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/Rooms.csv");

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] roomLines = lines[i].Split(',');

                this.rooms.Add(new Room(int.Parse(roomLines[0]), roomLines[1], roomLines[2],
                    int.Parse(roomLines[3]), int.Parse(roomLines[4]), int.Parse(roomLines[5]),
                    int.Parse(roomLines[6])));
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error loading rooms from csv\n" + e.Message);
        }
    }
    
    // TODO implement
    private void AddItemToRooms()
    {
        throw new NotImplementedException();
    }
    
    // TODO: make it so that if the player tries to go a direction that doesn't exist the program wont crash
    public void MoveRoom(String direction)
    {
        string directionString = direction.ToLower();
        
        switch (directionString)
        {
            case "north":
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.NorthId);
                break;
            case "south":
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.SouthId);
                break;
            case "east":
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.EastId);
                break;
            case "west":
                this.currentRoom = this.rooms.Find(r => r.RoomId == this.currentRoom.WestId);
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
    
    // getters and setters
    public List<Room> Rooms { get => rooms; set => rooms = value; }
    public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }
}