using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Core.EditPageContent
{
    public sealed class DALSectionPart : IBLSectionPart
    {
        [Key]
        public Guid SectionPartId { get; set; }

        /// <summary>
        /// Title1, header1, paragraph1
        /// </summary>
        public string Type { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(DALPageSection))]
        public Guid PageSectionFK { get; set; }

        public DALPageSection DALPageSection { get; set; }

        [NotMapped]
        public IBLPageSection PageSection 
        {
            get => DALPageSection;
            set => DALPageSection = (DALPageSection)value; 
        }
    }
}
