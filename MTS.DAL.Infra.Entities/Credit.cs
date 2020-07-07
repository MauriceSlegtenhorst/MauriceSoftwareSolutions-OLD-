using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.DAL.Entities
{
    public sealed class Credit
    {
        public int Id { get; set; }
        public string MadeBy { get; set; }
        public string GotFrom { get; set; }
        public string LinkToImage { get; set; }
        public string AuthorWebsite { get; set; }
    }
}
