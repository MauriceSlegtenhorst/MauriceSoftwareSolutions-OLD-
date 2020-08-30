using System;
using System.Collections.Generic;

namespace MTS.DAL.Entities.Core.EditPageContent
{
    public sealed class DALPageSection
    {
        public Guid Id { get; set; }

        public string PageName { get; set; }

        public string Header { get; set; }

        public List<DALParagraph> Paragraphs { get; set; }
    }
}
