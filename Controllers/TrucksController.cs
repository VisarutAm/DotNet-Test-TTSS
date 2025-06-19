using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Test_TTSS.DTOs;
using DotNet_Test_TTSS.Interfaces;
using DotNet_Test_TTSS.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Test_TTSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrucksController : ControllerBase
    {
        private readonly ITrucksRepository _truckRepo;

        public TrucksController(ITrucksRepository truckRepo)
        {
            _truckRepo = truckRepo;
        }
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] TrucksDto dto)
        {
            //Console.WriteLine($"Received DTO: AreaId={dto.AreaId}, UrgencyLevel={dto.UrgencyLevel}, TimeConstraintHours={dto.TimeConstraintHours}");

            //foreach (var kvp in dto.RequiredResources)
            // {
            //     Console.WriteLine($"RequiredResources: {kvp.Key} = {kvp.Value}");
            // }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var truck = dto.ToTruck();
            await _truckRepo.AddAsync(truck);

            return CreatedAtAction(nameof(Create), new { id = truck.TruckId }, dto);
        }
    }
}