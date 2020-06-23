using Microsoft.AspNetCore.Identity;
using MTS.BL.Infra.APILibrary;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using static MTS.Core.GlobalLibrary.Constants;

namespace MTS.DAL.API.Models
{
    public class EFUserAccount : IdentityUser
    {
        #region Name
        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        [Column(TypeName = "int")]
        public AccessLevel AccessLevel { get; set; }

        public bool IsAdmitted { get; set; }

        public static explicit operator UserAccount(EFUserAccount efUserAccount)
        {
            var userAccount = new UserAccount();

            foreach (PropertyInfo property in typeof(EFUserAccount).GetProperties())
            {
                // Ignore exceptions
                try
                {
                    property.SetValue(userAccount, typeof(EFUserAccount).GetProperty(property.Name).GetValue(efUserAccount));
                }
                catch { }
            }

            return userAccount;
        }
        #endregion
    }
}
