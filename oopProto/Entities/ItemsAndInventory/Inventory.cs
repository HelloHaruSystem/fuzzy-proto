namespace oopProto.ItemsAndInventory;

public class Inventory
{
    private List<Item> items;
    private int maxCapacity;
    private int currentCapacity;

    public Inventory()
    {
        items = new List<Item>();
        maxCapacity = 10;
        currentCapacity = 0;
    }
    
    // Getters and setters
    public int MaxCapacity { get => maxCapacity; set => maxCapacity = value; }
    public int CurrentCapacity { get => currentCapacity; set => currentCapacity = value; }
    public List<Item> Items { get => items; set => items = value; }
}