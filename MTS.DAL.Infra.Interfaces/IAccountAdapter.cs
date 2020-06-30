using MTS.BL.Infra.APILibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.DAL.Infra.Interfaces
{
    public interface IAccountAdapter
    {
        Task<UserAccount> CreateByEmailAndPasswordAsync(string email, string password);

        Task<UserAccount> CreateByAccountAsync(UserAccount userAccount);

        Task<UserAccount> ReadByIdAsync(string id);

        Task<UserAccount> ReadByEmailAsync(string email);

        Task<IEnumerable<UserAccount>> ReadAllAsync();

        Task<bool> WriteAsync(UserAccount userAccount);

        Task<bool> DeleteById(string id);

        Task<bool> ConfirmEmailAsync(ConfirmEmailHolder confirmEmailHolder);
    }
}