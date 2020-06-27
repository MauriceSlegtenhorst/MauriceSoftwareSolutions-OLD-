using MTS.BL.Infra.APILibrary;
using System.Threading.Tasks;

namespace MTS.DAL.Infra.Interfaces
{
    public interface IAccountFunctions
    {
        Task<IEFUserAccount> Create(string email, string password);
        Task<IEFUserAccount> Create(UserAccount userAccount);
    }
}