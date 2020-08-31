using System;

namespace MTS.BL.Infra.Interfaces.Standard.EditPageContent
{
    public interface IBLSectionPart
    {
        Guid SectionPartId { get; set; }

        string Type { get; set; }

        string Content { get; set; }

        public Guid PageSectionId { get; set; }
        public IBLPageSection PageSection { get; set; }
    }
}
