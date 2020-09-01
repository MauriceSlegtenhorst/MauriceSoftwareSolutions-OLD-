using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Core
{
    public sealed class DALCredit
    {
        [Key]
        public Guid CreditId { get; set; }
        public string MadeBy { get; set; }
        public string GotFrom { get; set; }
        public string LinkToImage { get; set; }
        public string AuthorWebsite { get; set; }
    }
}
