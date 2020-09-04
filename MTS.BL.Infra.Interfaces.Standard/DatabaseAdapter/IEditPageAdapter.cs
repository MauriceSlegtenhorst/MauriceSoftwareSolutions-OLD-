using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter
{
    public interface IEditPageAdapter
    {
        Task<ICollection<IBLPageSection>> ReadByPageRouteAsync(string pageRoute);

        Task<IBLPageSection> ReadByIdAsync(string id);

        Task UpdateByPageSectionsAsync(ICollection<IBLPageSection> blPageSections);
    }
}
