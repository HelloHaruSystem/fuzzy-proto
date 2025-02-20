using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.UserInterface;

namespace oopProto;

class Driver
{
    static async Task Main(string[] args)
    {
        GameUi ui = new GameUi();

        // test start \\
        
        await RoomRepository.DbTest();
        Console.ReadKey();
        
        // test 2 start \\ TODO: fix
        await RoomService.TestRepository();
        // test 2 end  \\
        
        //  test end  \\
        
        ui.StartGame();
    }
}