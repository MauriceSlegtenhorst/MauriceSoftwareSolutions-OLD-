using Microsoft.AspNetCore.Identity;
using MTS.DAL.Infra.APILibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.DAL.Infra.Interfaces
{
    public interface IAccountAdapter
    {
        Task<IEFUserAccount> CreateByEmailAndPasswordAsync(string email, string password);

        Task<IEFUserAccount> CreateByAccountAsync(UserAccount userAccount);

        Task<IEFUserAccount> ReadByIdAsync(string id);

        Task<IEFUserAccount> ReadByEmailAsync(CredentialHolder credentialHolder);

        Task<IEnumerable<IEFUserAccount>> ReadAllAsync();

        Task<IdentityResult> WriteAsync(UserAccount userAccount);

        Task<IdentityResult> DeleteByIdAsync(string id, string callerEmail);

        Task<IdentityResult> AddRolesToAccountAsync(string id, byte roles);

        Task<IdentityResult> RemoveRolesFromAccountAsync(string id, byte roles);

        Task<IdentityResult> ConfirmEmailAsync(string id, string code);
    }
}