using MTS.DAL.Infra.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    public interface ISeedData
    {
        Task<IEnumerable<EFUserAccount>> GetDefaultAccountsSeedDataAsync();
    }
}