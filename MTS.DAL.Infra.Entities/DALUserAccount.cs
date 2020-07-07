using Microsoft.AspNetCore.Identity;
using MTS.PL.Infra.Interfaces.Standard;

namespace MTS.PL.Entities.Core
{
    public class DALUserAccount : IdentityUser, IBLUserAccount
    {
        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        public bool IsAdmitted { get; set; }
    }
}
