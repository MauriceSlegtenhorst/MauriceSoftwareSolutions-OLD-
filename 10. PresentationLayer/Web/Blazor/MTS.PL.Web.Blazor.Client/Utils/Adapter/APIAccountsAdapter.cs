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
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Entities.Standard;

namespace MTS.PL.Web.Blazor.Client.Utils.Adapter
{
    public class APIAccountsAdapter : DataAdaptor
    {
        public static HttpClient httpClient;

        public static List<PLUserAccount> PLUserAccounts { get; set; }

        public override object Read(DataManagerRequest dataManager, string key = null)
        {
            if (PLUserAccounts == null)
                return null;

            if (dataManager.Search != null && dataManager.Search.Count > 0)
            {
                // Searching
                PLUserAccounts = DataOperations.PerformSearching(PLUserAccounts, dataManager.Search).ToList();
            }
            if (dataManager.Sorted != null && dataManager.Sorted.Count > 0)
            {
                // Sorting
                PLUserAccounts = DataOperations.PerformSorting(PLUserAccounts, dataManager.Sorted).ToList();
            }
            if (dataManager.Where != null && dataManager.Where.Count > 0)
            {
                // Filtering
                PLUserAccounts = DataOperations.PerformFiltering(PLUserAccounts, dataManager.Where, dataManager.Where[0].Operator).ToList();
            }

            int count = PLUserAccounts.Count();

            if (dataManager.Skip != 0)
            {
                //Paging
                PLUserAccounts = DataOperations.PerformSkip(PLUserAccounts, dataManager.Skip).ToList();
            }
            if (dataManager.Take != 0)
            {
                PLUserAccounts = DataOperations.PerformTake(PLUserAccounts, dataManager.Take).ToList();
            }

            return dataManager.RequiresCounts ? new DataResult() { Result = PLUserAccounts, Count = count } : (object)PLUserAccounts;
        }

        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            string url = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT}";

            var userAccount = data as PLUserAccount;

            if (userAccount == null)
            {
                throw new Exception("Data could not be converted to an useraccount");
            }

            HttpResponseMessage result;

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


                PLUserAccounts.Insert(0, data as PLUserAccount);


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

            var newUserAccount = data as PLUserAccount;

            if (newUserAccount == null)
            {
                throw new Exception("Data could not be converted to an useraccount");

            }

            HttpResponseMessage result;

            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(newUserAccount), Encoding.UTF8, Constants.MediaTypes.JSON);
                result = await httpClient.PatchAsync(url, stringContent);
            }
            catch
            {
                throw;
            }

            if (result.IsSuccessStatusCode)
            {
                return newUserAccount;
            }
            else
            {
                throw new Exception($"Call to server was unsuccessfull. {result.ReasonPhrase}");
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
            catch
            {
                throw;
            }

            if (result.IsSuccessStatusCode)
            {
                if (!PLUserAccounts.Remove(PLUserAccounts.Where(account => account.Id == userAccount.Id).FirstOrDefault()))
                {
                    throw new Exception("Error removing account locally. Server side account has been deleted");
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
