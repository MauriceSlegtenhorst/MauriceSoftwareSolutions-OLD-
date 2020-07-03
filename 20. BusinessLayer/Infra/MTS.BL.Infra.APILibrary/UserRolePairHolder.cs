using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Infra.APILibrary
{
    public sealed class UserRolePairHolder
    {
        [Required]
        public string Id { get; set; }
        
        [Required]
        public byte Roles { get; set; }
    }
}
