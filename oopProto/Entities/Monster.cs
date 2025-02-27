using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public class Monster : Entity
{
    private string _sprite;
    private int _roomId;
    
    public Monster(int id, string name, int maxHp, int strength, int defense, int speed, int avoidance, Weapon equippedWeapon, string sprite, int roomId) 
        : base(id, name, maxHp, strength, defense, speed, avoidance, equippedWeapon)
    {
        this._sprite = sprite;
        this._roomId = roomId;
    }
    
    // getters and setters
    public string Sprite { get => _sprite; set => _sprite = value; }
    public int RoomId { get => _roomId; set => _roomId = value; }

    // generated Equals and has code methods for comparing objects
    private sealed class MonsterEqualityComparer : IEqualityComparer<Monster>
    {
        public bool Equals(Monster? x, Monster? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return x._id == y._id && x._name == y._name && x._maxHp == y._maxHp && x._currentHp == y._currentHp && x._strength == y._strength && x._defense == y._defense && x._speed == y._speed && x._avoidance == y._avoidance && x._sprite == y._sprite;
        }

        public int GetHashCode(Monster obj)
        {
            var hashCode = new HashCode();
            hashCode.Add(obj._id);
            hashCode.Add(obj._name);
            hashCode.Add(obj._maxHp);
            hashCode.Add(obj._currentHp);
            hashCode.Add(obj._strength);
            hashCode.Add(obj._defense);
            hashCode.Add(obj._speed);
            hashCode.Add(obj._avoidance);
            hashCode.Add(obj._sprite);
            return hashCode.ToHashCode();
        }
    }

    public static IEqualityComparer<Monster> MonsterComparer { get; } = new MonsterEqualityComparer();
}