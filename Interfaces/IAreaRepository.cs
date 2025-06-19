using DotNet_Test_TTSS.Models;

namespace DotNet_Test_TTSS.Application.Interfaces
{
    public interface IAreaRepository
    {
        Task AddAsync(Area area);
    }
}
