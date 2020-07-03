using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.DAL.DatabaseAccess.Utils
{
    internal sealed class TokenValidationOptionsBuilder
    {
        internal static TokenValidationParameters Build(string issuerSigningKey)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey)),
                ClockSkew = TimeSpan.Zero
            };
        } 
    }
}
