using MTS.PL.Infra.Interfaces.Standard;
using System;

namespace MTS.PL.Infra.Entities.Standard
{
    public sealed class PLSectionPart : IPLSectionPart
    {
        public Guid SectionPartId { get; set; }

        /// <summary>
        /// Title1, header1, paragraph1
        /// </summary>
        public string Type { get; set; }

        public string Content { get; set; }

        public Guid PageSectionId { get; set; }
    }
}
