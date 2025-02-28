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
    
    public Monster GetMonsterCopy(int monsterId, int currentRoomId, int currentHp)
    {
        Monster monster = this._monsters.Find(m => m.Id == monsterId) 
                    ?? throw new KeyNotFoundException();
        
        Monster monsterToCopy = new Monster(monster.Id, monster.Name, monster.MaxHp, monster.Strength, monster.Defense,
            monster.Speed, monster.Avoidance, monster.EquippedWeapon, monster.Sprite, currentRoomId, currentHp);
            
        return monsterToCopy;
    }
    
    // getters and setters
    public List<Monster> Monsters { get => _monsters; set => _monsters = value; }
    
}