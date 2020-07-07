using MTS.Core.GlobalLibrary;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IUserRolePairHolder
    {
        string Id { get; set; }
        Constants.Roles Roles { get; set; }
    }
}