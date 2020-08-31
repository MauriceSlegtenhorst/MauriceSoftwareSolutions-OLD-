using System;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IPLSectionPart
    {
        public Guid SectionPartId { get; set; }

        /// <summary>
        /// Title1, header1, paragraph1
        /// </summary>
        string Type { get; set; }

        string Content { get; set; }

        Guid PageSectionId { get; set; }
    }
}
