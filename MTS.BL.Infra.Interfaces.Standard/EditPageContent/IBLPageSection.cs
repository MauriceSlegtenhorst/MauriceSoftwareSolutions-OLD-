using System;
using System.Collections.Generic;

namespace MTS.BL.Infra.Interfaces.Standard.EditPageContent
{
    public interface IBLPageSection
    {
        Guid PageSectionId { get; set; }

        string PageRoute { get; set; }

        ICollection<IBLSectionPart> Parts { get; set; }
    }
}
