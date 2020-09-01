using MTS.PL.Infra.Interfaces.Standard;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MTS.PL.Infra.Entities.Standard
{
    public sealed class PLPageSection : IPLPageSection
    {
        public Guid PageSectionId { get; set; }

        public string PageRoute { get; set; }

        public ICollection<PLSectionPart> PLSectionParts { get; set; }

        //[IgnoreDataMember]
        //public ICollection<IPLSectionPart> SectionParts
        //{
        //    get
        //    {
        //        if (PLSectionParts == null || PLSectionParts.Count == 0)
        //            return null;

        //        ICollection<IPLSectionPart> plParts = new List<IPLSectionPart>();

        //        foreach (PLSectionPart dalSectionPart in PLSectionParts)
        //        {
        //            IPLSectionPart plPart = dalSectionPart;

        //            plParts.Add(plPart);
        //        }

        //        return plParts;
        //    }

        //    set
        //    {
        //        if (value == null || value.Count == 0)
        //            return;

        //        ICollection<PLSectionPart> plParts = new List<PLSectionPart>();

        //        foreach (IPLSectionPart plSectionPart in value)
        //        {
        //            PLSectionPart plPart = (PLSectionPart)plSectionPart;

        //            plParts.Add(plPart);
        //        }

        //        PLSectionParts = plParts;
        //    }
        //}
    }
}
