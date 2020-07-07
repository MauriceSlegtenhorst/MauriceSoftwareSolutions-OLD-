using MTS.PL.Infra.Interfaces.Standard;
using MTS.Core.GlobalLibrary;
using System.ComponentModel.DataAnnotations;

namespace MTS.PL.Entities.Standard
{
    public sealed class UserRolePairHolder : IUserRolePairHolder
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public Constants.Roles Roles { get; set; }
    }
}
