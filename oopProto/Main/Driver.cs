using oopProto.Entities.Factory;
using oopProto.Entities.Repositorys;
using oopProto.UserInterface;
using oopProto.UserInterface.UserInput;

namespace oopProto;

class Driver
{
    static async Task Main(string[] args)
    {
        Console.ReadKey();
        
        GameUi ui = await  LoadOrNew.StartNewOrLoad();
        
        Console.Clear();
        await RoomRepository.DbTest();
        Console.ReadKey();
        
        ui.StartGame();
    }
}