using MTS.BL.Infra.Interfaces.Standard.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter
{
    public interface ICreditAdapter
    {
        Task<ICollection<IBLCreditCategory>> ReadAllAsync();
        Task<IBLCreditCategory> ReadByCategoryIdAsync(string id);
        Task<IBLCredit> ReadByCreditIdAsync(string id);
        Task UpdateByCreditCategoriesAsync(ICollection<IBLCreditCategory> blCreditCategories);
        Task UpdateByCreditIdAsync(IBLCredit blCredit);
    }
}