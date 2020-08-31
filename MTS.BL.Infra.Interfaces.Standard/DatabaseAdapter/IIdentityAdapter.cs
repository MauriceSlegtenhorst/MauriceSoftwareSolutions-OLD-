using MTS.BL.Infra.Interfaces.Standard;
using System.Threading.Tasks;

namespace MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter
{
    public interface IIdentityAdapter
    {
        Task<IAuthentificationResult> LogIn(ICredentialHolder credentials);

        Task<bool> LogOut();
    }
}
