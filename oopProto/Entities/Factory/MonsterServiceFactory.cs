using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;

namespace oopProto.Entities.Factory;

public class MonsterServiceFactory
{
    public static async Task<MonsterService> CreateMonsterService(ItemService itemService)
    {
        MonsterRepository repository = new MonsterRepository();
        IEnumerable<Monster> loadedMonsters = await repository.GetMonsters(itemService);
        
        MonsterService monsterService = new MonsterService(loadedMonsters.ToList());
        
        return monsterService;
    }
}