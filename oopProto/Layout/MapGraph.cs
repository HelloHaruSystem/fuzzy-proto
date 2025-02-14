using System;
using System.Collections.Generic;
using oopProto.ItemsAndInventory;

namespace oopProto.Layout;

public class MapGraph
{
    private Dictionary<Room, List<PathEdge>> adjacentRooms;
    private Room startRoom;

    public MapGraph(Room startRoom)
    {
        adjacentRooms = new Dictionary<Room, List<PathEdge>>();
        this.startRoom = startRoom;
        this.adjacentRooms.Add(startRoom, new List<PathEdge>());
    }

    public void addRoom(string roomName, string description)
    {
        adjacentRooms.Add(new Room(roomName, description), new List<PathEdge>());
    }

    public void addRoom(Room room)
    {
        adjacentRooms.Add(room, new List<PathEdge>());
    }

    public void addItemToRoom(string roomName, Item item)
    {
        foreach (Room room in adjacentRooms.Keys)
        {
            if (room.RoomName.Equals(roomName))
            {
                room.addItem(item);
            }
        }
    }

    // add path methods and overloaders
    public void addPath(string srcPath, string dstPath)
    {
        Room srcRoom = findRoom(srcPath);
        Room dstRoom = findRoom(dstPath);
        
        adjacentRooms[srcRoom].Add(new PathEdge(srcRoom, dstRoom)); 
        adjacentRooms[dstRoom].Add(new PathEdge(dstRoom, srcRoom));
    }

    public void addPath(Room srcPath, string dstPath)
    {
        Room dstRoom = findRoom(dstPath);
        
        adjacentRooms[srcPath].Add(new PathEdge(srcPath, dstRoom));
        adjacentRooms[dstRoom].Add(new PathEdge(dstRoom, srcPath));
    }

    public void addPath(string srcPath, Room dstPath)
    {
        Room srcRoom = findRoom(srcPath);
        
        adjacentRooms[srcRoom].Add(new PathEdge(srcRoom, dstPath));
        adjacentRooms[dstPath].Add(new PathEdge(dstPath, srcRoom));
        
    }

    public void addPath(Room srcPath, Room dstPath)
    {
            adjacentRooms[srcPath].Add(new PathEdge(srcPath, dstPath));
            adjacentRooms[dstPath].Add(new PathEdge(dstPath, srcPath));
    }

    // findRoom find by searching for roomName used in addPath
    public Room findRoom(string roomName)
    {
        foreach (Room room in adjacentRooms.Keys)
        {
            if (room.RoomName.Equals(roomName))
            {
                return room;
            }
        }
        
        return null;
    }

    // TODO: Fix the print method!
    public void PrintMap()
    {
        foreach (var roomEntry in adjacentRooms)
        {
            Room room = roomEntry.Key;  
            List<PathEdge> paths = roomEntry.Value;  
            
            foreach (var path in paths)
            {
                Console.WriteLine(path.ToString());  
            }
        }
    }

    // generated equals method and getHashCode method
    protected bool Equals(MapGraph other)
    {
        return adjacentRooms.Equals(other.adjacentRooms) && startRoom.Equals(other.startRoom);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((MapGraph)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(adjacentRooms, startRoom);
    }
}