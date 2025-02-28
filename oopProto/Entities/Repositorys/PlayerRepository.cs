using Npgsql;
using oopProto.Entities.Services;
using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Repositorys;

public class PlayerRepository
{
    public async Task<Player>? GetPlayer(ItemService itemService) 
    {
        string sql = @"SELECT
                    id,
                    name,
                    max_hp,
                    strength,
                    defense,
                    speed,
                    avoidance,
                    weapon_id
                   FROM player";
        
        string connectionString = ConfigHelper.GetConnectionString();
        Player? player = null;
        
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
                int maxHp = reader.GetInt32(2);
                int strength = reader.GetInt32(3);
                int defense = reader.GetInt32(4);
                int speed = reader.GetInt32(5);
                int avoidance = reader.GetInt32(6);
                int weaponId = reader.GetInt32(7);

                // save to room entity
                player = new Player(id, name, maxHp, strength, defense, speed, avoidance, itemService.GetWeapon(weaponId), maxHp);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            throw;
        }

        return player;
    }

    public static int GetMaxId()
    {
        int maxId = 0;
        
        string sql = @"SELECT MAX(id) FROM player";
        
        string connectionString = ConfigHelper.GetConnectionString();

        try
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                maxId =reader.IsDBNull(0) ? 1 : reader.GetInt32(0);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }
        
        return maxId;
    }
}