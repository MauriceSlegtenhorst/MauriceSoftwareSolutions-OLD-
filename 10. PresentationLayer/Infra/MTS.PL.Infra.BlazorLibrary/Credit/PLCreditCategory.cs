using MTS.PL.Infra.Interfaces.Standard.Credit;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MTS.PL.Infra.Entities.Standard.Credit
{
    public sealed class PLCreditCategory : IPLCreditCategory
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public ICollection<PLCredit> PLCredits { get; set; }

        [JsonIgnore]
        public ICollection<IPLCredit> Credits 
        {
            get
            {
                if (PLCredits == null || PLCredits.Count == 0)
                    return null;

                ICollection<IPLCredit> plCredits = new List<IPLCredit>();

                foreach (PLCredit plCredit in PLCredits)
                {
                    IPLCredit credit = plCredit;

                    plCredits.Add(credit);
                }

                return plCredits;
            }

            set
            {
                if (value == null || value.Count == 0)
                    return;

                ICollection<PLCredit> plCredits = new List<PLCredit>();

                foreach (IPLCredit credit in value)
                {
                    PLCredit plCredit = (PLCredit)credit;

                    plCredits.Add(plCredit);
                }

                PLCredits = plCredits;
            }
        }
    }
}
