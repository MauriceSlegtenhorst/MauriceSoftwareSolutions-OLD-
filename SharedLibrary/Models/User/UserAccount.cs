using Microsoft.AspNetCore.Identity;
using SharedLibrary.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models.User
{
    public class UserAccount : IdentityUser
    {
        #region Name
        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        [Column(TypeName = "int")]
        public AccessLevel AccessLevel { get; set; }
        #endregion
    }
}
