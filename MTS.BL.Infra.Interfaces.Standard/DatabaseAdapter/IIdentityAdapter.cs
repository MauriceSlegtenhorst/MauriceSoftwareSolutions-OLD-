using System.Threading.Tasks;

namespace MTS.PL.Infra.Interfaces.Standard.DatabaseAdapter
{
    public interface IIdentityAdapter
    {
        Task<IAuthentificationResult> LogIn(ICredentialHolder credentials);

        Task<bool> LogOut();
    }
}
