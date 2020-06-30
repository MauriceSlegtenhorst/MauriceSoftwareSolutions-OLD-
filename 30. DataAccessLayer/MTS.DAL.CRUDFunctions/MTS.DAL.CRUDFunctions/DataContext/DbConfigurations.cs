

using Microsoft.Extensions.Configuration;
using System.IO;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    internal sealed class DbConfigurations
    {
        internal DbConfigurations()
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder.AddUserSecrets<DbConfigurations>();

            //string path = Path.Combine(Directory.GetCurrentDirectory(), "secrets.json");

            //configBuilder.AddJsonFile(path, false);

            //configBuilder.AddEnvironmentVariables();

            IConfigurationRoot root = configBuilder.Build();

            SqlConnectionString = root.GetConnectionString("localdatabaseconnection");
            IssuerSigningKey = root["ValidateIssuerSigningKey:Key"];
            AuthMessageSenderOptions = root.GetSection("AuthMessageSenderOptions");
        }

        internal string SqlConnectionString { get; private set; }
        internal string IssuerSigningKey { get; private set; }
        internal IConfigurationSection AuthMessageSenderOptions { get; private set; }
    }
}
