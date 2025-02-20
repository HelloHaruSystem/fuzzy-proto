using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.Layout;

namespace oopProto.Entities.Factory;

public class RoomServiceFactory
{

    public static async Task<RoomService> CreateRoomService()
    {
        RoomRepository repository = new RoomRepository();
        IEnumerable<Room> loadedRooms = await repository.GetRooms();
        List<Room> rooms = loadedRooms.ToList(); 
        RoomService service = new RoomService(rooms);
        
        return service;
    }
}