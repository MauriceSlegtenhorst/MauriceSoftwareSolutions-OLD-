using System;
using System.Collections.Generic;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Dialog
{
    public sealed class DialogParameters
    {
        private Dictionary<string, object> parameters;

        public DialogParameters()
        {
            parameters = new Dictionary<string, object>();
        }

        public void Add(string parameterName, object value)
        {
            parameters[parameterName] = value;
        }

        /// <exception cref="ArgumentException">Thrown when parameteris not valid</exception>
        /// <exception cref="KeyNotFoundException">Thrown when the provided key was not found in the dictionairy</exception>
        /// <exception cref="InvalidCastException">Thrown when casting to the provided generic type was not possible</exception>
        public T Get<T>(string parameterName)
        {
            if (String.IsNullOrEmpty(parameterName))
                throw new ArgumentException($"{nameof(parameterName)} cannot be null or empty");

            if (parameters.ContainsKey(parameterName) == false)
                throw new KeyNotFoundException($"{nameof(parameterName)} {parameterName} does not exist");

            return (T)parameters[parameterName];
        }
    }
}
