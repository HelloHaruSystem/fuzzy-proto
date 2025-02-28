using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Factory;

public class PlayerServiceFactory
{
    public static async Task<PlayerService> CreatePlayerServiceFromSave(ItemService itemService)
    {
        PlayerRepository repository = new PlayerRepository();
        ItemRepository itemRepository = new ItemRepository();
        Player loadedPlayer = await repository.GetPlayer(itemService) ??
                              throw new KeyNotFoundException("Player not found");
        
        IEnumerable<Item> loadedItems = await itemRepository.GetPlayerItems(itemService, loadedPlayer.Id);
        List<Item> playerItems = loadedItems.ToList();
        
        PlayerService playerService = new PlayerService(loadedPlayer);
        
        foreach (Item item in playerItems)
        {
            playerService.AddItem(item);
        }
        
        return playerService;
    }
    
    public static PlayerService CreatePlayerServiceFromScratch(ItemService itemService, Player newplayer)
    {
        PlayerService playerService = new PlayerService(newplayer);
        
        return playerService;
    }
}