using System.Threading.Tasks;

namespace ProjectTask.Services.DatabaseSeed
{
    public interface ISeed
    {
        Task SeedAsync();
    }
}
