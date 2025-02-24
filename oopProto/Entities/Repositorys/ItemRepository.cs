using Npgsql;
using oopProto.ItemsAndInventory;

namespace oopProto.Entities.Repositorys;

public class ItemRepository
{
    public async Task<IEnumerable<Item>> GetPotions()
    {
        string sql = @"SELECT
                        id,
                        name,
                        healing_amount
                       FROM potions";

        string connectionString = ConfigHelper.GetConnectionString();
        List<Item> potionList = new List<Item>();

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
                int healingAmount = reader.GetInt32(2);

                Potion potion = new Potion(id, name, healingAmount);

                potionList.Add(potion);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw;
        }
        
        return potionList;
    }
    
    public async Task<IEnumerable<Item>> GetWeapons()
    {
        string sql = @"SELECT
                        id,
                        name,
                        damage,
                        usages,
                        is_ranged
                       FROM weapons";

        string connectionString = ConfigHelper.GetConnectionString();
        List<Item> weaponList = new List<Item>();

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
                int damage = reader.GetInt32(2);
                int usages = reader.GetInt32(3);
                bool isRanged = reader.GetBoolean(4);

                Weapon weapon = new Weapon(id, name, damage, usages, isRanged);

                weaponList.Add(weapon);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw;
        }
        
        return weaponList;
    }


    public async Task<IEnumerable<Item>> GetAllItems()
    {
        List<Item> items = new List<Item>();
        
        items.AddRange(await GetPotions());
        items.AddRange(await GetWeapons());
        
        return items;
    } 
    
}