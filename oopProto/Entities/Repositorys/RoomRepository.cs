using Npgsql;

namespace oopProto.Entities.Repositorys;

public class RoomRepository
{
 
    // DB TEST remove later!
    //TODO: remove when done
    public static async void dbTest()
    {
        string connectionString = ConfigHelper.GetConnectionString();
        
        // connect to the Postgres server
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();
        
        Console.WriteLine("The PostgreSQL version: {0}", connection.PostgreSqlVersion);    
    }

}