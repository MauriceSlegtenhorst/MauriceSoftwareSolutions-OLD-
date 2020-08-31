using System;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IPLPageSection
    {
        Guid PageSectionId { get; set; }

        string PageRoute { get; set; }

        IPLSectionPart[] DALSectionParts { get; set; }
    }
}
