using Npgsql;
using oopProto.Entities.Services;
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

    public async Task<IEnumerable<Item>> GetPlayerItems(ItemService itemService, int currentPlayerId)
    {
        string sql = @"SELECT
                        item_id,
                        player_id
                       FROM items_in_room_or_inventory";

        string connectionString = ConfigHelper.GetConnectionString();
        List<Item> playerItemList = new List<Item>();

        try
        {
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            await using var command = new NpgsqlCommand(sql, connection);
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int itemId = reader.GetInt32(0);
                int playerId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                if (playerId == currentPlayerId)
                {
                    Item item = itemService.GetItemCopy(itemId);
                    if (item != null)
                    {
                        playerItemList.Add(item);
                    }    
                }
                
            }
        } catch (NpgsqlException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        return playerItemList;
    }
    
    public async Task<IEnumerable<Item>> GetRoomItems(ItemService itemService, int currentPlayerId)
    {
        string sql = @"SELECT
                        save_id,
                        item_id,
                        room_id
                       FROM items_in_room_or_inventory";

        string connectionString = ConfigHelper.GetConnectionString();
        List<Item> roomItemList = new List<Item>();
        
        try
        {
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            await using var command = new NpgsqlCommand(sql, connection);
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int saveID = reader.GetInt32(0);
                int itemId = reader.GetInt32(1);
                int roomId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

                if (saveID == currentPlayerId)
                {
                    Item item = itemService.GetItemCopy(itemId);
                    if (item != null)
                    {
                        item.RoomId = roomId;
                        roomItemList.Add(item);
                    }    
                }
            }
        } catch (NpgsqlException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        return roomItemList;
    }

    public async Task<IEnumerable<Item>> GetAllItems()
    {
        List<Item> items = new List<Item>();
        
        items.AddRange(await GetPotions());
        items.AddRange(await GetWeapons());
        
        return items;
    }

    public void DeleteItemFromRoom(Item item, int roomId)
    {
        string sql = @$"
                                    DELETE FROM items_in_room_or_inventory
                                    WHERE ctid = (
                                        SELECT ctid FROM items_in_room_or_inventory
                                            WHERE item_id = {item.Id} AND room_id = {roomId}
                                            ORDER BY ctid
                                            LIMIT 1);";
        
        string connectionString = ConfigHelper.GetConnectionString();
        
        try
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error deleting item: {e.Message}");
        }
    }
    
    public void DeleteItemFromInventory(Item item, int playerId)
    {
        string sql = @$"
                                    DELETE FROM items_in_room_or_inventory
                                    WHERE ctid = (
                                        SELECT ctid FROM items_in_room_or_inventory
                                            WHERE item_id = {item.Id} AND player_id = {playerId}
                                            ORDER BY ctid
                                            LIMIT 1);";
        
        string connectionString = ConfigHelper.GetConnectionString();
        
        try
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error deleting item: {e.Message}");
        }
    }
    
    public void AddItemToInventory(Item item, int playerId)
    {
        string sql = @$"INSERT INTO items_in_room_or_inventory (save_id, item_id, player_id)
                        VALUES ({playerId}, {item.Id}, {playerId});";
        
        string connectionString = ConfigHelper.GetConnectionString();
        
        try
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine($"Error deleting item: {e.Message}");
        }
    }
    
}