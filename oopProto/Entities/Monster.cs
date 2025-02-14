using oopProto.ItemsAndInventory;

namespace oopProto.Entities;

public class Monster : Entity
{
    private string monsterName;
    int monsterStrength;
    private Weapon equipedWeapon;

    public Monster(int maxHp, string monsterName, int monsterStrength, Weapon equipedWeapon) : base()
    {
        this.maxHp = maxHp;
        this.monsterName = monsterName;
        this.monsterStrength = monsterStrength;
        this.equipedWeapon = equipedWeapon;
    }

    public void Attack(Player player)
    {
        int dealtDmg = monsterStrength + equipedWeapon.Damage;
       
        player.recieveDamage(dealtDmg);
    }
    
    // getters and setters
    public string MonsterName { get => monsterName; set => monsterName = value; }
    public Weapon EquipedWeapon { get => equipedWeapon; set => equipedWeapon = value; }
}