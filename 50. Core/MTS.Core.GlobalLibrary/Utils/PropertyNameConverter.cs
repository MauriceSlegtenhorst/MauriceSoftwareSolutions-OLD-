using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Core.GlobalLibrary.Utils
{
    public static class PropertyNameConverter
    {
        public static string ConvertFromProperty(string propertyName)
        {
            if (String.IsNullOrWhiteSpace(propertyName) || String.IsNullOrEmpty(propertyName))
                return String.Empty;

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(propertyName[0]);

            for (int i = 1; i < propertyName.Length; i++)
            {
                if (char.IsUpper(propertyName[i]))
                    stringBuilder.Append($" {char.ToLower(propertyName[i])}");
                else
                    stringBuilder.Append(propertyName[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
