using MTS.BL.Infra.Interfaces.Standard.Credit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Core.Credit
{
    public sealed class DALCreditCategory : IBLCreditCategory
    {
        [Key]
        public Guid CreditCategoryId { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(DALCredit.CreditCategoryFK))]
        public ICollection<DALCredit> DALCredits { get; set; }

        [NotMapped]
        public ICollection<IBLCredit> Credits 
        {
            get
            {
                if (DALCredits == null || DALCredits.Count == 0)
                    return null;

                ICollection<IBLCredit> blCredits = new List<IBLCredit>();

                foreach (DALCredit dalCredit in DALCredits)
                {
                    IBLCredit blCredit = dalCredit;

                    blCredits.Add(blCredit);
                }

                return blCredits;
            }

            set
            {
                if (value == null || value.Count == 0)
                    return;

                ICollection<DALCredit> dalCredits = new List<DALCredit>();

                foreach (IBLCredit blCredit in value)
                {
                    DALCredit dalCredit = (DALCredit)blCredit;

                    dalCredits.Add(dalCredit);
                }

                DALCredits = dalCredits;
            }
        }
    }
}
