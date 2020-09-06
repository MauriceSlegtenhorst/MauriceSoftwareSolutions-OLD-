using MTS.BL.Infra.Interfaces.Standard.Credit;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Core.Credit
{
    public sealed class DALCredit : IBLCredit
    {
        [Key]
        public Guid CreditId { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string MadeBy { get; set; }

        public string MadeByWebsite { get; set; }

        public string GotFrom { get; set; }

        public string GotFromWebsite { get; set; }

        public string LinkToImage { get; set; }

        [ForeignKey(nameof(DALCreditCategory.CreditCategoryId))]
        public Guid CreditCategoryFK { get; set; }
    }
}
