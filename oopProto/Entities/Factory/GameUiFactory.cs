using oopProto.Entities.Services;
using oopProto.UserInterface;
using oopProto.UserInterface.UserInput;

namespace oopProto.Entities.Factory;

public class GameUiFactory
{
    public static async Task<GameUi> CreateGameUiFromSave(int playerId)
    {
        ItemService iService = await ItemServiceFactory.CreateItemService();
        MonsterService mService = await MonsterServiceFactory.CreateMonsterService(iService);
        RoomService rService = await RoomServiceFactory.CreateRoomService();
        PlayerService pService = await PlayerServiceFactory.CreatePlayerServiceFromSave(playerId, iService);
        
        await rService.LoadMonstersToRooms(playerId, mService);
        await rService.LoadItemsToRooms(iService, playerId);
        
        GameUi gameUi = new GameUi(rService, iService, mService, pService);

        return gameUi;
    }
    
    public static async Task<GameUi> CreateGameUiFromScratch()
    {
        ItemService iService = await ItemServiceFactory.CreateItemService();
        MonsterService mService = await MonsterServiceFactory.CreateMonsterService(iService);
        RoomService rService = await RoomServiceFactory.CreateRoomService();

        Player newPlayer = CreateNewPlayer.CreatenewPlayer();
        PlayerService pService = PlayerServiceFactory.CreatePlayerServiceFromScratch(iService, newPlayer);
        
        rService.LoadDefaultMonstersToRooms(mService);
        await rService.LoadItemsToRooms(iService, pService.GetPlayer().Id);
        
        GameUi gameUi = new GameUi(rService, iService, mService, pService);
        
        return gameUi;
    }
}