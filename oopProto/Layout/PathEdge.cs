namespace oopProto.Layout;

public class Edge
{
    private Room sourceRoom;
    private Room destinationRoom;

    public Edge(Room sourceRoom, Room destinationRoom)
    {
        this.sourceRoom = sourceRoom;
        this.destinationRoom = destinationRoom;
    }

    public override string ToString()
    {
        return sourceRoom.ToString() +  "  -> " + destinationRoom.ToString();
    }
}