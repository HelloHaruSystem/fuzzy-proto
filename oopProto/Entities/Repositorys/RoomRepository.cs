using Npgsql;
using oopProto.Layout;

namespace oopProto.Entities.Repositorys;

public class RoomRepository
{
 
    // DB TEST remove later!
    //TODO: remove when done
    public static async void DbTest()
    {
        string connectionString = ConfigHelper.GetConnectionString();
        
        // connect to the Postgres server
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();
        
        Console.WriteLine("The PostgreSQL version: {0}", connection.PostgreSqlVersion);    
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
                        west_id
                       FROM
                        rooms"; 
        
        string connectionString = ConfigHelper.GetConnectionString();
        List<Room> rooms = new List<Room>();

        try
        {
            // open connection
            await using var connection = new NpgsqlConnection(connectionString);
            // await connection.OpenAsync(); // opening the connection

            // create sql command
            await using var command = new NpgsqlCommand(sql, connection);

            // create a new data reader by executing the command
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                int northId = reader.GetInt32(3);
                int southId = reader.GetInt32(4);
                int eastId = reader.GetInt32(5);
                int westId = reader.GetInt32(6);

                // save to room entity
                Room room = new Room(id, name, description, northId, southId, eastId, westId);
                
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