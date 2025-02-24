namespace oopProto.ItemsAndInventory;

public class Potion : Item
{
    private int healingAmount;

    public Potion(int id, string name) : base(id, name)
    {
        this.Id = id;
        this.Name = name;
        
    }
    
    // getters and setters
    public int HealingAmount
    {
        get => healingAmount; set => healingAmount = value;
    }
}