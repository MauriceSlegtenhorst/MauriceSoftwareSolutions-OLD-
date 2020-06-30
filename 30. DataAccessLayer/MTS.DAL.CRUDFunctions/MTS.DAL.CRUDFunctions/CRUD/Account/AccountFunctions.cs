using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MTS.BL.Infra.APILibrary;
using MTS.Core.GlobalLibrary;
using MTS.Core.GlobalLibrary.Utils;
using MTS.DAL.Infra.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.CRUD.Account
{
    public sealed class AccountFunctions : IAccountFunctions
    {
        private readonly UserManager<EFUserAccount> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountFunctions(
            UserManager<EFUserAccount> userManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        #region Create
        public async Task<IEFUserAccount> CreateByEmailAndPassword(string email, string password)
        {
            var efUserAccount = new EFUserAccount
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await _userManager.CreateAsync(efUserAccount, password);

            if (result != null && result.Succeeded)
            {
                await SendConfirmationEmail(efUserAccount);

                return await _userManager.FindByEmailAsync(email);
            }
            else
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                throw new Exception(JsonConvert.SerializeObject(errors));
            }
        }

        public async Task<IEFUserAccount> CreateByAccount(UserAccount userAccount)
        {
            var efUserAccount = new EFUserAccount();
            PropertyCopier<UserAccount, EFUserAccount>.Copy(userAccount, efUserAccount);

            IdentityResult result = await _userManager.CreateAsync(efUserAccount, userAccount.Password);
            if (result != null && result.Succeeded)
            {
                await SendConfirmationEmail(efUserAccount);

                return await _userManager.FindByEmailAsync(userAccount.Email);
            }
            else
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                throw new Exception(JsonConvert.SerializeObject(errors));
            }
        }
        #endregion

        #region Read
        public async Task<IEFUserAccount> ReadById(string id)
        {

        }

        public async Task<IEFUserAccount> ReadByEmail(string email)
        {

        }

        public async Task<IEFUserAccount> ReadAll()
        {

        }
        #endregion

        #region Write

        #endregion

        #region Delete

        #endregion
    }

}
