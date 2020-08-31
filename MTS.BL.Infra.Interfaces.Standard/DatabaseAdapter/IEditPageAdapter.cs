using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using System.Threading.Tasks;

namespace MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter
{
    public interface IEditPageAdapter
    {
        Task<IBLPageSection[]> ReadByPageRouteAsync(string pageRoute);

        Task<IBLPageSection> ReadByIdAsync(string id);
    }
}
