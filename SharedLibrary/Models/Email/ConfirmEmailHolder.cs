using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models.Email
{
    public sealed class ConfirmEmailHolder
    {
        public string UserId { get; set; }
        public string code { get; set; }
    }
}
