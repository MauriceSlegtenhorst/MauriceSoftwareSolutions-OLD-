using System.Threading.Tasks;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}
