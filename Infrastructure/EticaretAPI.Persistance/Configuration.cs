using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EticaretAPI.Persistance
{
    static class Configuration
    {
        static IConfigurationRoot configuration;

        static Configuration()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/EticaretAPI.API"))
                .AddJsonFile("appsettings.json")
                .Build();
        }

        static public string ConnectionString
        {
            get
            {
                return configuration.GetConnectionString("DefaultConnection");
            }
        }
    }
}
