using System;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IPLPageSection
    {
        Guid PageSectionId { get; set; }

        int SectionNumber { get; set; }

        string PageRoute { get; set; }
    }
}
