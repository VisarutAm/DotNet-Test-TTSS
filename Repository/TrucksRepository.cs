using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Test_TTSS.Data;
using DotNet_Test_TTSS.Interfaces;
using DotNet_Test_TTSS.Models;

namespace DotNet_Test_TTSS.Repository
{
    public class TrucksRepository : ITrucksRepository
    {
        private readonly SupabaseDbContext _context;

        public TrucksRepository(SupabaseDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Truck truck)
        {
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();        }

       
    }
}