using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;

namespace oopProto.Entities.Factory;

public class PlayerServiceFactory
{
    public static async Task<PlayerService> CreatePlayerService(ItemService itemService)
    {
        PlayerRepository repository = new PlayerRepository();
        Player loadedPlayer = await repository.GetPlayer(itemService) ??
                              throw new KeyNotFoundException("Player not found");
        
        PlayerService playerService = new PlayerService(loadedPlayer);
        
        return playerService;
    }
}