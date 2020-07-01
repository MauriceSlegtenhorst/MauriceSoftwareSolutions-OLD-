using MTS.BL.Infra.APILibrary;
using System.Threading.Tasks;

namespace MTS.BL.Infra.Interfaces
{
    public interface IIdentityAdapter
    {
        Task<AuthentificationResult> LogIn(CredentialHolder credentials);

        Task<bool> LogOut();
    }
}
