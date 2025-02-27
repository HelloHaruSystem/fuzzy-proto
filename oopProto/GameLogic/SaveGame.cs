using Npgsql;
using oopProto.Entities.Services;

namespace oopProto.Entities.GameLogic;

public class SaveGame
{
    public void SaveGameData(PlayerService playerService, RoomService roomService, MonsterService monsterService)
    {
        // db stuff here
        // TODO: Implement...
        /*try
        {
            SavePlayer(playerService.GetPlayer());
            SavePlayerItems(playerService.GetPlayer().Id, playerService.GetPlayer().PlayerInventory.Items);

            SaveRoomItems(roomService.Rooms);
            SaveMonsters(MonsterService.Monsters);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error saving game data: {e.Message}");
        }*/
    }
}