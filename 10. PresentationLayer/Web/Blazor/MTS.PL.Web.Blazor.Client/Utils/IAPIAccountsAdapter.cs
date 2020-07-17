using MTS.PL.Infra.Entities.Standard;
using Syncfusion.Blazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils
{
    public interface IAPIAccountsAdapter
    {
        List<PLUserAccount> PLUserAccounts { get; set; }

        Task<object> InsertAsync(DataManager dataManager, object data, string key);
        object Read(DataManagerRequest dataManager, string key = null);
        Task<object> RemoveAsync(DataManager dataManager, object id, string keyField, string key);
        Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key);
    }
}