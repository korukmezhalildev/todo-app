
using Microsoft.Extensions.Configuration;


namespace Case.Persistance.Config;

static class BaseConfiguration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            return configurationManager.GetConnectionString("MsSqlConnStr");
        }
    }
}