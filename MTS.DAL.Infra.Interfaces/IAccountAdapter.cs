using Microsoft.AspNetCore.Identity;
using MTS.BL.Infra.APILibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.Infra.Interfaces
{
    public interface IAccountAdapter
    {
        Task<IEFUserAccount> CreateByEmailAndPasswordAsync(string email, string password);

        Task<IEFUserAccount> CreateByAccountAsync(UserAccount userAccount);

        Task<IEFUserAccount> ReadByIdAsync(string id);

        Task<IEFUserAccount> ReadByEmailAsync(string email);

        Task<IEnumerable<IEFUserAccount>> ReadAllAsync();

        Task<bool> WriteAsync(UserAccount userAccount);

        Task<bool> DeleteByIdAsync(string id);

        Task<IdentityResult> AddRolesToAccountAsync(UserRolePairHolder userRolePairHolder);

        Task<IdentityResult> RemoveRolesFromAccountAsync(UserRolePairHolder userRolePairHolder);

        Task<IdentityResult> ConfirmEmailAsync(ConfirmEmailHolder confirmEmailHolder);
    }
}