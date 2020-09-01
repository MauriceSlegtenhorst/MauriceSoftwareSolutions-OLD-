using System;
using System.Collections.Generic;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IPLPageSection
    {
        Guid PageSectionId { get; set; }

        string PageRoute { get; set; }
    }
}
