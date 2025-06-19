using DotNet_Test_TTSS.Application.Interfaces;
using DotNet_Test_TTSS.Data;
using DotNet_Test_TTSS.Models;

namespace DotNet_Test_TTSS.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly SupabaseDbContext _context;

        public AreaRepository(SupabaseDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();
        }
    }
}
