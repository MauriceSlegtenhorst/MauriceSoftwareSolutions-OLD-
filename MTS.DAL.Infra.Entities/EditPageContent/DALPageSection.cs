using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MTS.DAL.Entities.Core.EditPageContent
{
    public sealed class DALPageSection : IBLPageSection
    {
        [Key]
        public Guid PageSectionId { get; set; }

        public string PageRoute { get; set; }

        [ForeignKey("PageSectionFK")]
        public ICollection<DALSectionPart> DALSectionParts { get; set; }

        [NotMapped]
        public ICollection<IBLSectionPart> Parts
        {
            get 
            {
                if (DALSectionParts == null || DALSectionParts.Count == 0)
                    return null;

                ICollection<IBLSectionPart> blParts = new List<IBLSectionPart>();

                foreach (DALSectionPart dalSectionPart in DALSectionParts)
                {
                    IBLSectionPart blPart = dalSectionPart;

                    blParts.Add(blPart);
                }

                return blParts;
            }

            set
            {
                if (value == null || value.Count == 0)
                    return;

                ICollection<DALSectionPart> dalParts = new List<DALSectionPart>();

                foreach (IBLSectionPart blSectionPart in value)
                {
                    DALSectionPart dalPart = (DALSectionPart)blSectionPart;

                    dalParts.Add(dalPart);
                }

                DALSectionParts = dalParts;
            }
        }
    }
}
