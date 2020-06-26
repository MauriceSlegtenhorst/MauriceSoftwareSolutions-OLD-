using Microsoft.AspNetCore.Identity;
using MTS.DAL.API.Database;
using MTS.DAL.Infra.Entities;
using System.Threading.Tasks;

namespace MTS.DAL.CRUDFunctions
{
    public class AccountFunctions
    {
        private readonly UserManager<EFUserAccount> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountFunctions(
            UserManager<EFUserAccount> userManager,
            ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        #region Create
        public async Task<IdentityResult> Create(string email, string password)
        {
            var efUserAccount = new EFUserAccount
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await _userManager.CreateAsync(efUserAccount, password);
            if (result != null && result.Succeeded)
            {
                return await _userManager.FindByEmailAsync(email);
            }
            else
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                return HandleException(new Exception(errors.ToString()));
            }
        }
        #endregion

        #region Read

        #endregion

        #region Write

        #endregion

        #region Delete

        #endregion
    }

}
