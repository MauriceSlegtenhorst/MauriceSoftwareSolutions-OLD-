using Microsoft.AspNetCore.Identity;
using MTS.BL.Infra.Interfaces.Standard;

namespace MTS.DAL.Entities.Core
{
    public class DALUserAccount : IdentityUser, IBLUserAccount
    {
        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        public bool IsAdmitted { get; set; }
    }
}
