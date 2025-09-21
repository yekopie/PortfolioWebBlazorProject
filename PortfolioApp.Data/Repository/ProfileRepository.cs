using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Data.Repository
{
    public class ProfileRepository(AppDbContext context) : EfGenericRepository<Profile>(context), IProfileRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<Profile?> GetAboutAsync(int userId)
        {          
            return await _context.Profiles
                .Where(p => p.UserId == userId)
                .Include(p => p.Image)
                .Include(p => p.Testimonials)
                    .ThenInclude(t => t.Image)
                .Include(p => p.Skills)
                .Include(p => p.Projects)
                    .ThenInclude(pr => pr.Image)
                .FirstOrDefaultAsync();
        }

        public async Task<Profile?> GetResumeInformationsAsync(int userId)
        {
            return await _context.Profiles
                .Where(p => p.UserId == userId)
                .Include(p => p.Image)
                .Include(p => p.Educations)
                .Include(p => p.Experiences)
                .FirstOrDefaultAsync();
        }
    }
}
