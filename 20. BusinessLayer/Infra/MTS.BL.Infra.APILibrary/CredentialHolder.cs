using MTS.BL.Infra.Interfaces.Standard;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTS.BL.Entities.Standard
{
    public sealed class CredentialHolder : ICredentialHolder
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
