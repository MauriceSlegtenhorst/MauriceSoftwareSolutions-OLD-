using MTS.PL.Infra.Interfaces.Standard;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MTS.PL.Infra.Entities.Standard
{
    public sealed class PLPageSection : IPLPageSection
    {
        //TODO Convert all PL objects with an id to a hash of that id. In the front end they most not see database related info. But we still need reference to objects for later saving in the database.
        public Guid PageSectionId { get; set; }

        public int SectionNumber { get; set; }

        public string PageRoute { get; set; }

        public ICollection<PLSectionPart> PLSectionParts { get; set; }
    }
}
