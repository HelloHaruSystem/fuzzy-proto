using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public class Monster : Entity
{
    private string _sprite;
    
    public Monster(int id, string name, int maxHp, int strength, int defense, int speed, int avoidance, Weapon equippedWeapon, string sprite) 
        : base(id, name, maxHp, strength, defense, speed, avoidance, equippedWeapon)
    {
        this._sprite = sprite;
    }
    
    // getters and setters
    public string Sprite { get => _sprite; set => _sprite = value; }
}