using oopProto.Entities;

namespace oopProto.ItemsAndInventory;

public class Potion : Item
{
    private int _healingAmount;

    public Potion(int id, string name, int healingAmount) : base(id, name)
    {
        this.Id = id;
        this.Name = name;
        this._healingAmount = healingAmount;
    }

    // TODO: add something to the ui that tells the player how much they healed for!
    public override void Use(Player player)
    {
        player.CurrentHp += _healingAmount;
        if (player.CurrentHp > player.MaxHp) player.CurrentHp = player.MaxHp;
    }
    
    // getters and setters
    public int HealingAmount
    {
        get => _healingAmount; set => _healingAmount = value;
    }
}