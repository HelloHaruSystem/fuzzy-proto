using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public class Monster : Entity
{
    private int _id;
    private string _name;
    private int _strength;
    private Weapon _equipedWeapon;
    private string _sprite;
    

    public Monster(int maxHp, string monsterName, int monsterStrength, Weapon equipedWeapon, string sprite)
    {
        this.maxHp = maxHp;
        this.currentHp = maxHp;
        this._name = monsterName;
        this._strength = monsterStrength;
        this._equipedWeapon = equipedWeapon;
        this._sprite = sprite;
    }
    
    // getters and setters
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public Weapon EquipedWeapon { get => _equipedWeapon; set => _equipedWeapon = value; }
    public int Strength { get => _strength; set => _strength = value; }
    public string Sprite { get => _sprite; set => _sprite = value; }
}