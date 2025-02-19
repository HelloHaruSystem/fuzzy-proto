using oopProto.Entities.Repositorys;
using oopProto.UserInterface;

namespace oopProto;

class Driver
{
    static void Main(string[] args)
    {
        GameUi ui = new GameUi();

        // test start \\
        
        RoomRepository.dbTest();
        Console.ReadKey();
        
        //  test end  \\
        
        ui.StartGame();
    }
}