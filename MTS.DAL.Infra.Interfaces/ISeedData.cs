using MTS.BL.Infra.Interfaces.Standard;
using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.DAL.Interfaces.Standard
{
    public interface ISeedData
    {
        Task<IEnumerable<IBLUserAccount>> GetDefaultAccountsSeedDataAsync();

    }
}