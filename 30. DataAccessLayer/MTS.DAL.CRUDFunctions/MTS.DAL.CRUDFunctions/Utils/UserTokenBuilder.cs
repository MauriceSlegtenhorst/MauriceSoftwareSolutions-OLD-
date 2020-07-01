using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MTS.BL.Infra.APILibrary;
using MTS.BL.Infra.Entities;
using MTS.BL.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BL.DatabaseAccess.Utils
{
    internal sealed class UserTokenBuilder
    {
        internal static async Task<UserToken> BuildToken(EFUserAccount efUserAccount, UserManager<EFUserAccount> userManager, string issuerSigningKey)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, $"{efUserAccount.Email.GetHashCode()}{DateTime.UtcNow}{efUserAccount.PasswordHash.GetHashCode()}"),
                new Claim(ClaimTypes.Name, efUserAccount.ToString()),
                new Claim(ClaimTypes.Email, efUserAccount.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in await userManager.GetRolesAsync(efUserAccount))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken(
                userId: efUserAccount.Id,
                loginProvider: "MTS-Security",
                userName: efUserAccount.UserName,
                expiration: expiration,
                jwtSecurityToken: new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
