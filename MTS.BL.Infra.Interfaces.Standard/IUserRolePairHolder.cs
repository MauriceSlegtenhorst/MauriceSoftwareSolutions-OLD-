using MTS.Core.GlobalLibrary;

namespace MTS.BL.Infra.Interfaces.Standard
{
    public interface IUserRolePairHolder
    {
        string Id { get; set; }
        Constants.Roles Roles { get; set; }
    }
}