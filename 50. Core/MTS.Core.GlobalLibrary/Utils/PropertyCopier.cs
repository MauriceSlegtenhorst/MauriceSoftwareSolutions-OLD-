using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Core.GlobalLibrary.Utils
{
    public class PropertyCopier<TFrom, TTo> where TFrom : class
                                            where TTo : class//, new()
    {
        public static void Copy(TFrom fromParent, TTo toChild)
        {
            var parentProperties = fromParent.GetType().GetProperties();
            var childProperties = toChild.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        if(parentProperty.GetValue(fromParent) != childProperty.GetValue(toChild))
                        {
                            childProperty.SetValue(toChild, parentProperty.GetValue(fromParent));
                        }
                        
                        break;
                    }
                }
            }
        }
    }
}
