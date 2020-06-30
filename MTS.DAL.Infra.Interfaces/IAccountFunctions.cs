using MTS.BL.Infra.APILibrary;
using System.Threading.Tasks;

namespace MTS.DAL.Infra.Interfaces
{
    public interface IAccountFunctions
    {
        Task<IEFUserAccount> CreateByEmailAndPassword(string email, string password);
        Task<IEFUserAccount> CreateByAccount(UserAccount userAccount);
    }
}