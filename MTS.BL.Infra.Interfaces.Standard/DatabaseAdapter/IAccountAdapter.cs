using Microsoft.AspNetCore.Identity;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces.Standard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter
{
    public interface IAccountAdapter
    {
        Task<IBLUserAccount> CreateByEmailAndPasswordAsync(string email, string password);

        Task<IBLUserAccount> CreateByAccountAsync(IPLUserAccount userAccount);

        Task<IBLUserAccount> ReadByIdAsync(string id);

        Task<IBLUserAccount> ReadByEmailAsync(string email);

        Task<IEnumerable<IBLUserAccount>> ReadAllAsync();

        Task<IdentityResult> WriteAsync(IPLUserAccount userAccount);

        Task<IdentityResult> DeleteByIdAsync(string id, string callerEmail);

        Task<IdentityResult> AddRolesToAccountAsync(string id, Constants.Roles roles);

        Task<IdentityResult> RemoveRolesFromAccountAsync(string id, Constants.Roles roles);

        Task<IdentityResult> ConfirmEmailAsync(string id, string code);
    }
}