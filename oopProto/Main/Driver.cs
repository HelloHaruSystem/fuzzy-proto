﻿using oopProto.Entities.Factory;
using oopProto.Entities.Repositorys;
using oopProto.UserInterface;

namespace oopProto;

class Driver
{
    static async Task Main(string[] args)
    {
        GameUi ui = await GameUiFactory.CreateGameUiFromSave();
        
        Console.Clear();
        await RoomRepository.DbTest();
        Console.ReadKey();
        
        ui.StartGame();
    }
}