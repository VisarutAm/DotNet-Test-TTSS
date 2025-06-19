using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DotNet_Test_TTSS.Data;
using DotNet_Test_TTSS.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;


namespace DotNet_Test_TTSS.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly SupabaseDbContext _context;
        private readonly RedisDbContext _rediscontext;

        public AssignmentRepository(SupabaseDbContext context, RedisDbContext rediscontext)
        {
            _context = context;
            _rediscontext = rediscontext;
        }



        public async Task<IEnumerable<object>> GetAllAreaTruckDataAsync()
        {
            var result = await _context.Areas
                .SelectMany(area => _context.Trucks,
                    (area, truck) => new
                    {
                        area.AreaId,
                        area.UrgencyLevel,
                        area.RequiredResources,
                        area.TimeConstraintHours,
                        truck.TruckId,
                        truck.AvailableResources,
                        truck.TravelTimeToArea
                        // Include other required fields
                    })
                .OrderByDescending(x => x.UrgencyLevel)
                .ToListAsync();

            return result;
        }
        //--------------Redis---------------------------
        public async Task<T?> GetAsync<T>(string key)
        {
            var json = await _rediscontext.Db.StringGetAsync(key);
            if (json.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>(json!);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var json = JsonSerializer.Serialize(value);
            await _rediscontext.Db.StringSetAsync(key, json, expiry);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            return await _rediscontext.Db.KeyDeleteAsync(key);
        }
    }
}