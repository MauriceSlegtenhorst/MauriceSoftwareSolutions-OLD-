using MTS.BL.Infra.APILibrary;
using MTS.Core.GlobalLibrary;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Pages.Account.CRUD
{
    public class APIAccountsAdapter : DataAdaptor<UserAccount>
    {
        private readonly HttpClient _httpClient;
        public APIAccountsAdapter(HttpClient client)
        {
            _httpClient = client;
        }
        public override Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
        {
            return base.BatchUpdateAsync(dataManager, changedRecords, addedRecords, deletedRecords, keyField, key, dropIndex);
        }

        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            string url = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT}";
            await _httpClient.PutAsJsonAsync(url, data);
            return data;
        }

        public async override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
          
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }

        public override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            return base.UpdateAsync(dataManager, data, keyField, key);
        }
    }
}
