

using Microsoft.Extensions.Configuration;
using System.IO;

namespace MTS.BL.DatabaseAccess.DataContext
{
    public sealed class DbConfigurations
    {
        public DbConfigurations()
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder.AddUserSecrets<DbConfigurations>();

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
