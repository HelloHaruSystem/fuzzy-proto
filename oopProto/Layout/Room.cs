using System;
using System.Collections.Generic;
using oopProto.ItemsAndInventory;

namespace oopProto.Layout;

public class Room
{
    private string roomName;
    private string description;
    private List<Item> items;

    public Room(string roomName, string description)
    {
        this.roomName = roomName;
        this.description = description;
        this.items = new();
    }

    public void addItem(Item item)
    {
        items.Add(item);
    }

    // TODO: add a proper toString() method
    public override string ToString()
    {
        return roomName;
    }
    /*public override string ToString()
    {
        return $"{roomName} - {description} (Items: {string.Join(", ", items.Select(i => i.ToString()))})";
    }*/
    
    // getters and setters
    public string RoomName => roomName;
    public string Description => description;

    // generated equals method and getHashCode method
    protected bool Equals(Room other)
    {
        return roomName == other.roomName && description == other.description && items.Equals(other.items);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Room)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(roomName, description, items);
    }
}