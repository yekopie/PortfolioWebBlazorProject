using PortfolioApp.Data.Entities;

namespace PortfolioApp.Data.Repository
{
    public interface IProfileRepository: IGenericRepository<Profile>
    {
        Task<Profile?> GetResumeInformationsAsync(int userId);
        Task<Profile?> GetAboutAsync(int userId);
    }
}
