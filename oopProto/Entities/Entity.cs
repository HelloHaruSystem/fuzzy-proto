
using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

// TODO: Change name to something else that monster and player have in common
public abstract class Entity
{
    protected int _id;
    protected string _name;
    protected int _maxHp;
    protected int _currentHp;
    protected int _strength;
    protected int _defense;
    protected int _speed;
    protected int _avoidance;
    protected Weapon _equippedWeapon;

    protected Entity(int id, string name, int maxHp, int strength, int defense, int speed, int avoidance, Weapon equippedWeapon)
    {
        this._id = id;
        this._name = name;
        this._maxHp = maxHp;
        this._strength = strength;
        this._defense = defense;
        this._speed = speed;
        this._avoidance = avoidance;
        this._equippedWeapon = equippedWeapon;
        
        this._currentHp = this._maxHp;
    }
    
    public void ReceiveDamage(int damage)
    {
        _currentHp -= damage;
        if (_currentHp < 0)
        {
            _currentHp = 0;
        }
    }

    public void ReceiveHeal(int heal)
    {
        _currentHp += heal;
        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
    }
    
    // getters and setters
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public int MaxHp { get => _maxHp; set => _maxHp = value; }
    public int CurrentHp { get => _currentHp; set => _currentHp = value; }
    public int Strength { get => _strength; set => _strength = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public int Speed { get => _speed; set => _speed = value; }
    public int Avoidance { get => _avoidance; set => _avoidance = value; }
    public Weapon EquippedWeapon  { get => _equippedWeapon; set => _equippedWeapon = value; }
}