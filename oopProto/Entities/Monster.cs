using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public class Monster : Entity
{
    private int id;
    private string name;
    private int strength;
    private Weapon equipedWeapon;
    private string sprite;
    

    public Monster(int maxHp, string monsterName, int monsterStrength, Weapon equipedWeapon, string sprite) : base()
    {
        this.maxHp = maxHp;
        this.name = monsterName;
        this.strength = monsterStrength;
        this.equipedWeapon = equipedWeapon;
        this.sprite = sprite;
    }
    
    // getters and setters
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public Weapon EquipedWeapon { get => equipedWeapon; set => equipedWeapon = value; }
    public int Strength { get => Strength; set => Strength = value; }
    public string Sprite { get => sprite; set => sprite = value; }
}