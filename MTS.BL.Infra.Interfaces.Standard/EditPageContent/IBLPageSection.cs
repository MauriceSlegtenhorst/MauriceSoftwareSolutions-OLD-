using System;

namespace MTS.BL.Infra.Interfaces.Standard.EditPageContent
{
    public interface IBLPageSection
    {
        Guid PageSectionId { get; set; }

        string PageRoute { get; set; }

        IBLSectionPart[] Parts { get; set; }
    }
}
