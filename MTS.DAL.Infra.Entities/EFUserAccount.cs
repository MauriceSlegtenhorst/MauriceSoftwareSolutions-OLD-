using Microsoft.AspNetCore.Identity;
using MTS.DAL.Infra.Interfaces;

namespace MTS.DAL.Entities
{
    public class EFUserAccount : IdentityUser, IEFUserAccount
    {
        public override string Id { get => base.Id; set => base.Id = value; }

        #region Custom properties
        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        public bool IsAdmitted { get; set; }
        #endregion
    }
}
