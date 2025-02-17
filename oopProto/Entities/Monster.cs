using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public class Monster : Entity
{
    private string name;
    int strength;
    private Weapon equipedWeapon;
    private int spriteId;
    

    public Monster(int maxHp, string monsterName, int monsterStrength, Weapon equipedWeapon) : base()
    {
        this.maxHp = maxHp;
        this.name = monsterName;
        this.strength = monsterStrength;
        this.equipedWeapon = equipedWeapon;
        
    }
    
    // getters and setters
    public string Name { get => name; set => name = value; }
    public Weapon EquipedWeapon { get => equipedWeapon; set => equipedWeapon = value; }
    public int Strength { get => Strength; set => Strength = value; }
    public int SpriteID { get => spriteId; set => spriteId = value; }
}