using PortfolioApp.Data.Entities;

namespace PortfolioApp.Data.Repository
{
    public interface IProfileRepository: IGenericRepository<Profile>
    {
        Task<Profile?> GetAboutAsync(int userId);
    }
}
