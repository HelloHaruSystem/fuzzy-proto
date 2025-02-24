using oopProto.Entities;

namespace oopProto.ItemsAndInventory;

public class Potion : Item
{
    private int healingAmount;

    public Potion(int id, string name, int healingAmount) : base(id, name)
    {
        this.Id = id;
        this.Name = name;
        this.healingAmount = healingAmount;
    }

    // TODO: add something to the ui that tells the player how much they healed for!
    public override void Use(Player player)
    {
        player.CurrentHp += healingAmount;
        if (player.CurrentHp > player.MaxHp) player.CurrentHp = player.MaxHp;
    }
    
    // getters and setters
    public int HealingAmount
    {
        get => healingAmount; set => healingAmount = value;
    }
}