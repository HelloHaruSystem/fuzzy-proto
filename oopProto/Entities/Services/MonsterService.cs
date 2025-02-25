using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Services;

public class MonsterService
{
    private List<Monster> _monsters;

    public MonsterService()
    {
        this._monsters = LoadMonsters();
    }

    // TODO load monsters
    private List<Monster> LoadMonsters()
    {
        throw new NotImplementedException();
    }
    
    public int Attack(Monster monster)
    {
        int dealtDmg = monster.Strength + monster.EquippedWeapon.Damage;
       
        return dealtDmg;
    }

    // TODO: implement
    public Weapon dropWeapon()
    {
        throw new NotImplementedException();
    } 
    
    
}