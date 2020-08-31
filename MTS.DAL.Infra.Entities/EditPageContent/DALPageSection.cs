using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Core.EditPageContent
{
    public sealed class DALPageSection : IBLPageSection
    {
        [Key]
        public Guid PageSectionId { get; set; }

        public string PageRoute { get; set; }

        public DALSectionPart[] DALSectionParts { get; set; }

        [NotMapped]
        public IBLSectionPart[] Parts
        {
            get => DALSectionParts;
            set => DALSectionParts = (DALSectionPart[])value;
        }
    }
}
