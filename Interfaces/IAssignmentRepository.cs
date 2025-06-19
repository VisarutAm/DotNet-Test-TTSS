using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Test_TTSS.Interfaces
{
    public interface IAssignmentRepository
    {
       Task<IEnumerable<object>> GetAllAreaTruckDataAsync();
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task<T?> GetAsync<T>(string key);
        Task<bool> DeleteAsync(string key);
       
    }
}