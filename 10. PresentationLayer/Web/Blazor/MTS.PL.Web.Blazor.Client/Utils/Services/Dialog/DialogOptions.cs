using Syncfusion.Blazor.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Dialog
{
    public class DialogOptions
    {
        public string XPosition { get; set; }
        public string YPosition { get; set; }
        public string Style { get; set; }
        public string Width { get; set; }
        public bool? HasHeader { get; set; }
        public bool? HasBackgroundCancel { get; set; }
        public bool? HasButtons { get; set; }
        public bool? HasCloseButton { get; set; }
    }
}
