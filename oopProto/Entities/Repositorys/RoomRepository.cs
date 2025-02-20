using Npgsql;
using oopProto.Layout;

namespace oopProto.Entities.Repositorys;

public class RoomRepository
{
 
    // DB TEST remove later!
    //TODO: remove when done
    public static async Task DbTest()
    {
        string connectionString = ConfigHelper.GetConnectionString();
        
        // connect to the Postgres server
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();
        
        Console.WriteLine("Database successfully loaded\nRunning PostgreSQL version: {0}", connection.PostgreSqlVersion);    
    }

    public async Task<IEnumerable<Room>> GetRooms() 
    {
        string sql = @"SELECT
                    id,
                    name,
                    description,
                    north_id,
                    south_id,
                    east_id,
                    west_id,
                    ascii_art
                   FROM rooms";
        
        string connectionString = ConfigHelper.GetConnectionString();
        List<Room> rooms = new List<Room>();

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
                string description = reader.GetString(2);
                int northId = reader.GetInt32(3);
                int southId = reader.GetInt32(4);
                int eastId = reader.GetInt32(5);
                int westId = reader.GetInt32(6);
                string asciiArt = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

                // save to room entity
                Room room = new Room(id, name, description, northId, southId, eastId, westId, asciiArt);
                
                rooms.Add(room);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            throw;
        }
        
        return rooms;
    }

}