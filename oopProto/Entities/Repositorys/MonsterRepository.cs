using Npgsql;
using oopProto.Entities.Services;
using oopProto.Layout;

namespace oopProto.Entities.Repositorys;

public class MonsterRepository
{
    public async Task<IEnumerable<Monster>> GetMonsters(ItemService itemService) 
    {
        string sql = @"SELECT
                    id,
                    name,
                    strength,
                    defense,
                    speed,
                    avoidance,
                    weapon_id,
                    sprite,
                    max_hp,
                    room_id
                   FROM monsters";
        
        string connectionString = ConfigHelper.GetConnectionString();
        List<Monster> monsterList = new List<Monster>();

        try
        {
            // open connection // using automatically closes after try block so no need to close the connection yourself
            await using var connection = new NpgsqlConnection(connectionString);
            
            // opening the connection
            await connection.OpenAsync(); 

            // create sql command
            await using var command = new NpgsqlCommand(sql, connection);

            // create a new data reader by executing the command
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int strength = reader.GetInt32(2);
                int defense = reader.GetInt32(3);
                int speed = reader.GetInt32(4);
                int avoidance = reader.GetInt32(5);
                int weaponId = reader.GetInt32(6);
                string sprite = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                int maxHp = reader.GetInt32(8);
                int roomId = reader.GetInt32(9);

                // save to room entity
                Monster monster = new Monster(id, name, maxHp, strength, defense, speed, avoidance, itemService.GetWeapon(weaponId), sprite, roomId, maxHp);
                
                monsterList.Add(monster);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            throw;
        }

        return monsterList;
    }
}