using oopProto.Entities.Repositorys;
using oopProto.Entities.Services;
using oopProto.UserInterface;

namespace oopProto;

class Driver
{
    static void Main(string[] args)
    {
        GameUi ui = new GameUi();

        // test start \\
        
        RoomRepository.DbTest();
        Console.ReadKey();
        
        // test 2 start \\ TODO: fix
        RoomService.testRepository();
        // test 2 end  \\
        
        //  test end  \\
        
        ui.StartGame();
    }
}