using MTS.PL.Infra.Interfaces.Standard.Credit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.PL.Infra.Entities.Standard.Credit
{
    public sealed class PLCredit : IPLCredit
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string MadeBy { get; set; }

        public string MadeByWebsite { get; set; }

        public string GotFrom { get; set; }

        public string GotFromWebsite { get; set; }

        public string LinkToImage { get; set; }
    }
}
