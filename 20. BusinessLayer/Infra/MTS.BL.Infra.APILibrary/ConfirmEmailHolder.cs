using MTS.PL.Infra.InjectionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.DAL.Infra.APILibrary
{
    public sealed class ConfirmEmailHolder : IConfirmEmailHolder
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
