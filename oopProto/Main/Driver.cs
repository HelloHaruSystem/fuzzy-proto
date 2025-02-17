using oopProto.ItemsAndInventory;
using oopProto.Layout;
using oopProto.UserInterface;

namespace oopProto;

class Driver
{
    static void Main(string[] args)
    {
        GameUi ui = new GameUi();
        
        ui.StartGame();
    }
}