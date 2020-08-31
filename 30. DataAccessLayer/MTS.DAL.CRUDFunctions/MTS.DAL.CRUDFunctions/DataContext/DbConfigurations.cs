using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MTS.DAL.DatabaseAccess.Utils;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    public sealed class DbConfigurations
    {
        internal string SqlConnectionString { get; private set; }
        internal string IssuerSigningKey { get; private set; }
        internal IConfigurationSection AuthMessageSenderOptions { get; private set; }
        internal TokenValidationParameters TokenValidationParameters { get; private set; }
        internal IdentityOptions IdentityOptions { get; private set; }

        public DbConfigurations()
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder.AddUserSecrets<DbConfigurations>();

            IConfigurationRoot root = configBuilder.Build();

            SqlConnectionString = root.GetConnectionString("localdatabaseconnection");
            IssuerSigningKey = root["ValidateIssuerSigningKey:Key"];
            AuthMessageSenderOptions = root.GetSection("AuthMessageSenderOptions");

            TokenValidationParameters = TokenValidationOptionsBuilder.Build(IssuerSigningKey);

            IdentityOptions = IdentityOptionsBuilder.Build();
        }
    }
}
