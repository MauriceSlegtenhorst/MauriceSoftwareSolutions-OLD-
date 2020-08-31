using MTS.PL.Infra.Interfaces.Standard;
using System;

namespace MTS.PL.Infra.Entities.Standard
{
    public sealed class PLPageSection : IPLPageSection
    {
        public Guid PageSectionId { get; set; }

        public string PageRoute { get; set; }

        public IPLSectionPart[] DALSectionParts { get; set; }
    }
}
