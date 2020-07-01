using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTS.BL.Infra.APILibrary
{
    public sealed class UserRolePairHolder
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public IEnumerable<string> Roles { get; set; }
    }
}
