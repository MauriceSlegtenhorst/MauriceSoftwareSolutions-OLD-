using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.BlazorLibrary;
using Newtonsoft.Json;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils
{
    public class APIAccountsAdapter : DataAdaptor
    {
        private readonly HttpClient _httpClient;

        private IEnumerable<UserAccount> _userAccounts;

        public APIAccountsAdapter(HttpClient httpClient, IEnumerable<UserAccount> userAccounts)
        {
            _httpClient = httpClient;
            _userAccounts = userAccounts;
        }

        public override object Read(DataManagerRequest dataManager, string key = null)
        {
            if (_userAccounts == null)
                return null;

            if (dataManager.Search != null && dataManager.Search.Count > 0)
            {
                // Searching
                _userAccounts = DataOperations.PerformSearching(_userAccounts, dataManager.Search);
            }
            if (dataManager.Sorted != null && dataManager.Sorted.Count > 0)
            {
                // Sorting
                _userAccounts = DataOperations.PerformSorting(_userAccounts, dataManager.Sorted);
            }
            if (dataManager.Where != null && dataManager.Where.Count > 0)
            {
                // Filtering
                _userAccounts = DataOperations.PerformFiltering(_userAccounts, dataManager.Where, dataManager.Where[0].Operator);
            }

            int count = _userAccounts.Count();

            if (dataManager.Skip != 0)
            {
                //Paging
                _userAccounts = DataOperations.PerformSkip(_userAccounts, dataManager.Skip);
            }
            if (dataManager.Take != 0)
            {
                _userAccounts = DataOperations.PerformTake(_userAccounts, dataManager.Take);
            }

            return dataManager.RequiresCounts ? new DataResult() { Result = _userAccounts, Count = count } : (object)_userAccounts;
        }

        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            string url = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT}";

            var userAccount = (UserAccount)data;

            HttpResponseMessage result = null;

            try
            {
                result = await _httpClient.PutAsJsonAsync(url, userAccount);
            }
            catch
            {
                throw;
            }

            if (result.IsSuccessStatusCode)
            {
                try
                {
                    data = JsonConvert.DeserializeObject<UserAccount>(await result.Content.ReadAsStringAsync());
                }
                catch
                {
                    throw;
                }

                if (data == null)
                {
                    throw new Exception("Deserialized data was null");
                }


                _userAccounts.ToList().Insert(0, data as UserAccount);
                

                return data;
            }
            else
            {
                throw new Exception("Call was unsuccesfull");
            }
        }

        public async override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            string url = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.UPDATE_BY_ACCOUNT}";

            var newUserAccount = data as UserAccount;

            if (newUserAccount == null)
            {
                throw new Exception("Data could not be converted to an useraccount");

            }

            HttpResponseMessage result = null;

            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(newUserAccount), Encoding.UTF8, Constants.MediaTypes.JSON);
                result = await _httpClient.PatchAsync(url, stringContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (result.IsSuccessStatusCode)
            {
                return data;
            }
            else
            {
                throw new Exception("Call to server was unsuccessfull");
            }
        }

        public async override Task<object> RemoveAsync(DataManager dataManager, object id, string keyField, string key)
        {
            var userAccount = _userAccounts.FirstOrDefault(account => account.Id == id.ToString());

            if (userAccount == null)
            {
                throw new Exception("Data could not be converted to an user account");
            }

            HttpResponseMessage result = null;

            string url = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.DELETE_BY_ID}?id={userAccount.Id}";

            try
            {
                result = await _httpClient.DeleteAsync(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (result.IsSuccessStatusCode)
            {
                if (!_userAccounts.ToList().Remove(_userAccounts.Where(account => account.Id == userAccount.Id).FirstOrDefault()))
                {
                    throw new Exception("Error removing locally. Server side account has been deleted");
                }

                return id;
            }
            else
            {
                throw new Exception("Call to server was unsuccesfull");
            }
        }
    }
}
