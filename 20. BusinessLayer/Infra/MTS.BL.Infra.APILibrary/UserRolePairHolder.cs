using MTS.BL.Infra.Interfaces.Standard;
using MTS.Core.GlobalLibrary;
using System.ComponentModel.DataAnnotations;

namespace MTS.BL.Entities.Standard
{
    public sealed class UserRolePairHolder : IUserRolePairHolder
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public Constants.Roles Roles { get; set; }
    }
}
