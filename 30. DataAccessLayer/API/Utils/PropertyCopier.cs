using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.DataAcces.AccountAPI.Utils
{
    internal class PropertyCopier<TParent, TChild> where TParent : class
                                            where TChild : class
    {
        internal static void Copy(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }
    }
}
