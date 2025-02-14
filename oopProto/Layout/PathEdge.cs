namespace oopProto.Layout;

// non weighted and bidirectional!
public class PathEdge
{
    private Room sourceRoom;
    private Room destinationRoom;

    public PathEdge(Room sourceRoom, Room destinationRoom)
    {
        this.sourceRoom = sourceRoom;
        this.destinationRoom = destinationRoom;
    }

    public override string ToString()
    {
        return sourceRoom.ToString() +  "  -> " + destinationRoom.ToString();
    }
    
    // getters and setters
    public Room DestinationRoom => destinationRoom;
    public Room SourceRoom => sourceRoom;

    // generated equals method and getHashCode method
    protected bool Equals(PathEdge other)
    {
        return sourceRoom.Equals(other.sourceRoom) && destinationRoom.Equals(other.destinationRoom);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((PathEdge)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(sourceRoom, destinationRoom);
    }
}