using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.UserInterface;

namespace oopProto;

class Driver
{
    static async Task Main(string[] args)
    {
        GameUi ui = await GameUi.CreateGameUi();
        
        await RoomRepository.DbTest();
        Console.ReadKey();
        
        ui.StartGame();
    }
}