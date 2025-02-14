using oopProto.ItemsAndInventory;
using oopProto.Layout;

namespace oopProto;

class Driver
{
    static void Main(string[] args)
    {
        // First creating the starting room
        Room castleEntrance = new Room("Castle Entrance", "The Entrance Hall to the castle");
        
        // creating map
        MapGraph map = new MapGraph(castleEntrance);
        
        // adding some rooms
        map.addRoom("Staircase", "Staircase leading to the tower");
        map.addRoom("Castle Garden", "The withered castle garden");
        map.addRoom("The old castle library", "The old castle library filled with secrets");
        map.addRoom("Castle Tower", "The castle tower");
        
        // creating items
        Item fireTome = new Tome("Fire Tome", "Fire");
        Item roseWhip = new Weapon("Rose Whip", 20, 10, false);
        
        // adding item to rooms
        map.addItemToRoom("The old castle library", fireTome);
        map.addItemToRoom("Castle Garden", roseWhip);
        map.addItemToRoom("Castle Tower", new Weapon("Crossbow", 15, 5, true));
        
        // adding paths from the entrance
        map.addPath(castleEntrance, "The old castle library");
        map.addPath(castleEntrance, "Staircase");
        map.addPath(castleEntrance, "Castle Garden");
        
        // adding rest of the paths
        map.addPath("Staircase", "Castle Tower");
        
        // printing the map
        map.PrintMap();
    }
}