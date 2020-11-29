using System.Threading.Tasks;

namespace Services.SeedService
{
    public interface ISeedService
    {
        Task AddProductsAsync();

        bool IsPopulate();
    }
}
