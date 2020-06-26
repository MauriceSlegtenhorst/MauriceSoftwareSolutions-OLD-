using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MTS.DAL.Infra.Entities
{
    public class EFUserAccount : IdentityUser
    {
        #region Name
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get => base.Id; set => base.Id = value; }

        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        public bool IsAdmitted { get; set; }
        #endregion
    }
}
