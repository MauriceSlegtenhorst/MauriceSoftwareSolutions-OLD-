using Microsoft.AspNetCore.Identity;

namespace SharedLibrary.Models.User
{
    public sealed class UserAccount : IdentityUser
    {
        #region Name
        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }
        #endregion
    }
}
