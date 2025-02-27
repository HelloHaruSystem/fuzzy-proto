namespace oopProto.Entities;

public class SaveSlot
{
    private int _id;
    private string _name;
    private string _dateCreated;
    private int _currentRoom;

    public SaveSlot(int id, string name, string dateCreated, int currentRoom)
    {
        this._id = id;
        this._name = name;
        this._dateCreated = dateCreated;
        this._currentRoom = currentRoom;
    }
    
    // getters and setters
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string DateCreated { get => _dateCreated; set => _dateCreated = value; }
    public int CurrentRoom { get => _currentRoom; set => _currentRoom = value; }
    
}