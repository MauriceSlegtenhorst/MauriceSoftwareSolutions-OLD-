using MTS.PL.Infra.InjectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BL.Infra.APILibrary
{
    public class UserAccount : IUserAccount
    {
        public static Task<UserAccount> ConvertFromAsync(object fromObject)
        {
            return new Task<UserAccount>(() =>
            {
                return ConvertFrom(fromObject);
            });
        }

        public static UserAccount ConvertFrom(object fromObject)
        {
            var userAccount = new UserAccount();
            List<Exception> exceptions = null;
            try
            {
                PropertyInfo[] propertyInfos = fromObject.GetType().GetProperties();
                if (propertyInfos.Any())
                {
                    foreach (PropertyInfo properyInfo in propertyInfos)
                    {
                        try
                        {
                            properyInfo.SetValue(userAccount, properyInfo.GetValue(fromObject));
                        }
                        catch (Exception ex)
                        {
                            if (exceptions == null)
                                exceptions = new List<Exception>();

                            exceptions.Add(ex);
                        }
                    }
                }
                else
                {
                    exceptions.Add(new ArgumentException("fromObject empty"));
                }

                if (exceptions != null)
                {
                    if (exceptions.Count > 1)
                        throw new AggregateException(exceptions);
                    else
                        throw exceptions[0];
                }

            }
            catch (AggregateException ex)
            {
                throw ex;
            }

            return userAccount;
        }

        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        public int AccessLevel { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string SecurityStamp { get; set; }

        public string PasswordHash { get; set; }

        public bool EmailConfirmed { get; set; }

        public string NormalizedEmail { get; set; }

        public string Email { get; set; }

        public string NormalizedUserName { get; set; }

        public string UserName { get; set; }

        public string Id { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
        public bool IsAdmitted { get; set; }
    }
}
