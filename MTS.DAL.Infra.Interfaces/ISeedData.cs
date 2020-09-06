using System.Threading.Tasks;

namespace MTS.DAL.Interfaces.Standard
{
    public interface ISeedData
    {
        Task SeedPageSectionsAsync(object builderObject);
        Task SeedAccountsAsync(object builderObject);
        Task SeedCredits(object builderObject);
    }
}