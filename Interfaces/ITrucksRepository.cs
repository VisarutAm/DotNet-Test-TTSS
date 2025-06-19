using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Test_TTSS.Models;

namespace DotNet_Test_TTSS.Interfaces
{
    public interface ITrucksRepository
    {
        Task AddAsync(Truck truck);
    }
}