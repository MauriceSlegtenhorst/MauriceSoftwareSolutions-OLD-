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
using MTS.PL.Infra.Interfaces.Standard;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Entities.Standard;

namespace MTS.PL.Web.Blazor.Client.Utils
{
    public class APIAccountsAdapter : DataAdaptor
    {
        public static HttpClient httpClient;

        public static IEnumerable<IPLUserAccount> PLUserAccounts { get; set; }

        public override object Read(DataManagerRequest dataManager, string key = null)
        {
            if (PLUserAccounts == null)
                return null;

            if (dataManager.Search != null && dataManager.Search.Count > 0)
            {
                // Searching
                PLUserAccounts = DataOperations.PerformSearching(PLUserAccounts, dataManager.Search);
            }
            if (dataManager.Sorted != null && dataManager.Sorted.Count > 0)
            {
                // Sorting
                PLUserAccounts = DataOperations.PerformSorting(PLUserAccounts, dataManager.Sorted);
            }
            if (dataManager.Where != null && dataManager.Where.Count > 0)
            {
                // Filtering
                PLUserAccounts = DataOperations.PerformFiltering(PLUserAccounts, dataManager.Where, dataManager.Where[0].Operator);
            }

            int count = PLUserAccounts.Count();

            if (dataManager.Skip != 0)
            {
                //Paging
                PLUserAccounts = DataOperations.PerformSkip(PLUserAccounts, dataManager.Skip);
            }
            if (dataManager.Take != 0)
            {
                PLUserAccounts = DataOperations.PerformTake(PLUserAccounts, dataManager.Take);
            }

            return dataManager.RequiresCounts ? new DataResult() { Result = PLUserAccounts, Count = count } : (object)PLUserAccounts;
        }

        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            string url = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT}";

            var userAccount = (IPLUserAccount)data;

            HttpResponseMessage result = null;

            try
            {
                result = await httpClient.PutAsJsonAsync(url, userAccount);
            }
            catch
            {
                throw;
            }

            if (result.IsSuccessStatusCode)
            {
                try
                {
                    data = JsonConvert.DeserializeObject<PLUserAccount>(await result.Content.ReadAsStringAsync());
                }
                catch
                {
                    throw;
                }

                if (data == null)
                {
                    throw new Exception("Deserialized data was null");
                }


                PLUserAccounts.ToList().Insert(0, data as IPLUserAccount);


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

            var newUserAccount = data as IPLUserAccount;

            if (newUserAccount == null)
            {
                throw new Exception("Data could not be converted to an useraccount");

            }

            HttpResponseMessage result = null;

            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(newUserAccount), Encoding.UTF8, Constants.MediaTypes.JSON);
                result = await httpClient.PatchAsync(url, stringContent);
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
            var userAccount = PLUserAccounts.FirstOrDefault(account => account.Id == id.ToString());

            if (userAccount == null)
            {
                throw new Exception("Data could not be converted to an user account");
            }

            HttpResponseMessage result = null;

            string url = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.DELETE_BY_ID}?id={userAccount.Id}";

            try
            {
                result = await httpClient.DeleteAsync(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (result.IsSuccessStatusCode)
            {
                if (!PLUserAccounts.ToList().Remove(PLUserAccounts.Where(account => account.Id == userAccount.Id).FirstOrDefault()))
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
