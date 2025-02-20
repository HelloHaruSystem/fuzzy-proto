using Microsoft.Extensions.Configuration;

namespace oopProto.Entities.Repositorys;

public static class ConfigHelper
{
    
    private static readonly IConfiguration _configuration;

    static ConfigHelper()
    {
        // build config from appsettings.json
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/")) // projects base directory
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // loads the Json file
            
            _configuration = config.Build(); // builds the config from the json file
    }
    
    public static string GetConnectionString()
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection")
            ?? throw new NullReferenceException("Default connection string is null");

        return connectionString;
    }
}