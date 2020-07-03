using MTS.DAL.Infra.APILibrary;
using System.Threading.Tasks;

namespace MTS.DAL.Infra.Interfaces
{
    public interface IIdentityAdapter
    {
        Task<AuthentificationResult> LogIn(CredentialHolder credentials);

        Task<bool> LogOut();
    }
}
