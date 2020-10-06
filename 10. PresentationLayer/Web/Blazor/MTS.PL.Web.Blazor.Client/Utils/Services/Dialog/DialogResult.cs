using System;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Dialog
{
    public class DialogResult
    {
        public object Data { get; }
        public Type DataType { get; }
        public bool Cancelled { get; }
        public Type DialogType { get; set; }

        protected DialogResult(object data, Type dataType, bool cancelled, Type dialogType)
        {
            Data = data;
            DataType = dataType;
            Cancelled = cancelled;
            DialogType = dialogType;
        }

        public static DialogResult Ok<T>(T result) => Ok(result, default);
        public static DialogResult Ok<T>(T result, Type dialogType) => new DialogResult(result, typeof(T), false, dialogType);

        public static DialogResult Cancel() => Cancel(default);
        public static DialogResult Cancel(Type dialogType) => new DialogResult(default, typeof(object), true, dialogType);
    }
}
