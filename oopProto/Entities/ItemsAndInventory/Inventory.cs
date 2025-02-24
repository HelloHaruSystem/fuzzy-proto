namespace oopProto.ItemsAndInventory;

public class Inventory
{
    private List<Item> _items;
    private int _maxCapacity;
    private int _currentCapacity;

    public Inventory()
    {
        _items = new List<Item>();
        _maxCapacity = 10;
        _currentCapacity = 0;
    }
    
    // Getters and setters
    public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }
    public int CurrentCapacity { get => _currentCapacity; set => _currentCapacity = value; }
    public List<Item> Items { get => _items; set => _items = value; }
}