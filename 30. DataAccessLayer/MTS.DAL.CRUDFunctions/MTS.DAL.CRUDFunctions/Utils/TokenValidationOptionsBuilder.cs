using Microsoft.IdentityModel.Tokens;
using MTS.Core.GlobalLibrary;
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
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey)),
                ClockSkew = TimeSpan.Zero,
                ValidAudience = Constants.API_BASE_ADDRESS,
                ValidIssuer = Constants.API_BASE_ADDRESS
            };
        } 
    }
}
