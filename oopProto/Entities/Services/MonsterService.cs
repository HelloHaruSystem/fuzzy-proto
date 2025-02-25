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
    
    // TODO: implement
    public Weapon dropWeapon()
    {
        throw new NotImplementedException();
    } 
    
    
}