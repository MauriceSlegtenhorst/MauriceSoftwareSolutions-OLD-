using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.BL.Infra.APILibrary
{
    public sealed class ConfirmEmailHolder
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
