using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Services;

public class MonsterService
{
    private List<Monster> _monsters;
    
    public MonsterService(List<Monster> monsters)
    {
        this._monsters = monsters
                         ?? new List<Monster>();
    }
    
    // TODO load monsters
    private List<Monster> LoadMonsters()
    {
        throw new NotImplementedException();
    }
    
    // getters and setters
    public List<Monster> Monsters { get => _monsters; set => _monsters = value; }
    
}