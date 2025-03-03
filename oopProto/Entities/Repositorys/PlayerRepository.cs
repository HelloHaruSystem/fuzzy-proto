using Npgsql;
using oopProto.Entities.Services;

namespace oopProto.Entities.Repositorys;

public class PlayerRepository
{
    public async Task<IEnumerable<string>> GetPlayerNameAndID()
    {
        string sql = @"SELECT
                    id,
                    name
                   FROM player";
        
        List<string> playerNames = new List<string>();
        string connectionString = ConfigHelper.GetConnectionString();

        try
        {
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            
            await using var command = new NpgsqlCommand(sql, connection);
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                
                string player = $"Id: {id} | Name: {name}";
                playerNames.Add(player);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error loading from database {e.Message}");
        }
        
        return playerNames;
    }
    
    public async Task<Player>? GetPlayer(int playerId, ItemService itemService, RoomService roomService) 
    {
        string sql = @$"SELECT
                    id,
                    name,
                    max_hp,
                    strength,
                    defense,
                    speed,
                    avoidance,
                    weapon_id,
                    current_hp,
                    current_room_id                    
                   FROM player
                   WHERE id = {playerId}";
        
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
                int currentHp = reader.GetInt32(8);
                int currentRoomId = reader.GetInt32(9);

                // save to room entity
                player = new Player(id, name, maxHp, strength, defense, speed, avoidance, itemService.GetWeapon(weaponId), currentHp);
                roomService.FindAndSetCurrentRoom(currentRoomId);
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

    public void SavePlayer(Player player, RoomService roomService)
    {
        string sql = @"
        UPDATE player
        SET 
            name = @name,
            max_hp = @maxHp,
            strength = @strength,
            defense = @defense,
            speed = @speed,
            avoidance = @avoidance,
            weapon_id = @weaponId,
            current_hp = @currentHp,
            current_room_id = @currentRoomId
        WHERE id = @id";

        string connectionString = ConfigHelper.GetConnectionString();

        try
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("@id", player.Id);
            command.Parameters.AddWithValue("@name", player.Name); 
            command.Parameters.AddWithValue("@maxHp", player.MaxHp);
            command.Parameters.AddWithValue("@strength", player.Strength);
            command.Parameters.AddWithValue("@defense", player.Defense);
            command.Parameters.AddWithValue("@speed", player.Speed);
            command.Parameters.AddWithValue("@avoidance", player.Avoidance);
            command.Parameters.AddWithValue("@weaponId", player.EquippedWeapon?.Id ?? (object)DBNull.Value); 
            command.Parameters.AddWithValue("@currentHp", player.CurrentHp);
            command.Parameters.AddWithValue("@currentRoomId", roomService.CurrentRoom?.RoomId ?? (object)DBNull.Value);
            
            command.ExecuteNonQuery();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw; // Re-throw the exception if necessary
        }
    }

    public void CreatePlayer(Player player)
    {
        string sql = @"
        INSERT INTO player (id, name, max_hp, strength, defense, speed, avoidance, weapon_id, current_hp, current_room_id)
        VALUES (
            @id,
            @name,
            @maxHp,
            @strength,
            @defense,
            @speed,
            @avoidance,
            @weaponId,
            @currentHp,
            @currentRoomId)";

        string connectionString = ConfigHelper.GetConnectionString();

        try
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("@id", player.Id);
            command.Parameters.AddWithValue("@name", player.Name); 
            command.Parameters.AddWithValue("@maxHp", player.MaxHp);
            command.Parameters.AddWithValue("@strength", player.Strength);
            command.Parameters.AddWithValue("@defense", player.Defense);
            command.Parameters.AddWithValue("@speed", player.Speed);
            command.Parameters.AddWithValue("@avoidance", player.Avoidance);
            command.Parameters.AddWithValue("@weaponId", player.EquippedWeapon?.Id ?? (object)DBNull.Value); 
            command.Parameters.AddWithValue("@currentHp", player.CurrentHp);
            command.Parameters.AddWithValue("@currentRoomId", 1);
            
            command.ExecuteNonQuery();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw;
        }
    }
}