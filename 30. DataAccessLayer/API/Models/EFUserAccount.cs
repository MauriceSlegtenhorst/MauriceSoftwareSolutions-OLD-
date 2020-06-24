using Microsoft.AspNetCore.Identity;
using MTS.BL.Infra.APILibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static MTS.Core.GlobalLibrary.Constants;

namespace MTS.DAL.API.Models
{
    public class EFUserAccount : IdentityUser
    {
        #region Name
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get => base.Id; set => base.Id = value; }

        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        [Column(TypeName = "int")]
        public AccessLevel AccessLevel { get; set; }

        public bool IsAdmitted { get; set; }
        #endregion
    }
}
