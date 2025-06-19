using DotNet_Test_TTSS.Application.Interfaces;
using DotNet_Test_TTSS.DTOs;
using DotNet_Test_TTSS.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DotNet_Test_TTSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IAreaRepository _areaRepo;

        public AreasController(IAreaRepository areaRepo)
        {
            _areaRepo = areaRepo;
        }
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AreasDto dto)
        {
            try
            {
                //         Console.WriteLine($"Received DTO: AreaId={dto.AreaId}, UrgencyLevel={dto.UrgencyLevel}, TimeConstraintHours={dto.TimeConstraintHours}");

                // foreach (var kvp in dto.RequiredResources)
                // {
                //     Console.WriteLine($"RequiredResources: {kvp.Key} = {kvp.Value}");
                // }
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                // Map ไปยัง Entity และบันทึก
                var area = dto.ToArea();
                await _areaRepo.AddAsync(area);

                return CreatedAtAction(nameof(Create), new { id = area.AreaId }, dto);
            }
            //  catch (JsonException)
            // {
            //     return BadRequest(400,new { message = "Malformed JSON" });
            // }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
}

