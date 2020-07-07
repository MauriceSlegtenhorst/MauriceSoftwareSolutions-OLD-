using MTS.PL.Infra.Interfaces.Standard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.PL.Interfaces.Standard
{
    public interface ISeedData
    {
        Task<IEnumerable<IBLUserAccount>> GetDefaultAccountsSeedDataAsync();
    }
}