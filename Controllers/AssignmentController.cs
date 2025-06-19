using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DotNet_Test_TTSS.DTOs;
using DotNet_Test_TTSS.Interfaces;
using DotNet_Test_TTSS.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Test_TTSS.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepo;
        private readonly IHttpClientFactory _httpClientFactory;

        public AssignmentController(IAssignmentRepository assignmentRepo, IHttpClientFactory httpClientFactory)
        {
            _assignmentRepo = assignmentRepo;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetAllData()
        {
            try
            {
                var data = await _assignmentRepo.GetAllAreaTruckDataAsync();
                return Ok(data);
            }
            catch
            {
                return StatusCode(500, new { message = "Failed to fetch data" });
            }
        }

        [HttpPost("assignments")]
        public async Task<IActionResult> PostAssignment([FromBody] AssignmentRequestDto request)
        {
            if (request == null || request.AreaId == null || request.ResourcesDelivered == null)
                return BadRequest(new { message = "Missing or Invalid request data" });

            try
            {
                var cacheData = await _assignmentRepo.GetAsync<List<AssignmentData>>("data");
                if (cacheData == null)
                {
                    var client = _httpClientFactory.CreateClient();
                    var response = await client.GetAsync("http://localhost:5142/api/data");
                    var json = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine($"Status Code: {response.StatusCode}");
                    //Console.WriteLine($"Response JSON: {json}");

                    var resultData = JsonSerializer.Deserialize<List<AssignmentData>>(json);
                    // var resultData = JsonSerializer.Deserialize<List<AssignmentData>>(json, new JsonSerializerOptions
                    // {
                    //     PropertyNameCaseInsensitive = true
                    // });
                    await _assignmentRepo.SetAsync("data", resultData, TimeSpan.FromMinutes(30));

                    return Ok(new { message = "Cache Created" });
                }

                var filtered = cacheData
                    .Where(d => d.AreaId == request.AreaId)
                    .Where(d => request.ResourcesDelivered.All(kv =>
                        d.AvailableResources.ContainsKey(kv.Key) &&
                        d.AvailableResources[kv.Key] >= kv.Value))
                    .ToList();

                var passedTimeConstraint = filtered
                    .Where(d =>
                        d.TravelTimeToArea.TryGetValue(request.AreaId, out var timeToArea) &&
                        timeToArea <= d.TimeConstraintHours)
                    .ToList();

                if (filtered.Count == 0)
                    return BadRequest(new { message = "RequiredResources cannot be delivered" });
                if (passedTimeConstraint.Count == 0)
                    return BadRequest(new { message = "Time constraint issue" });

                var oldAssignments = await _assignmentRepo.GetAsync<List<AssignmentResult>>("assignments") ?? new List<AssignmentResult>();
                var newAssignments = passedTimeConstraint.Select(item => new AssignmentResult
                {
                    AreaId = item.AreaId,
                    TruckId = item.TruckId,
                    ResourcesDelivered = request.ResourcesDelivered
                });

                // .AddRange() ไม่ลบของเดิมใน list — แค่ต่อท้ายเท่านั้น

                // ถ้าไม่ต้องการซ้ำ อาจใช้ .Union() แทนได้


                oldAssignments.AddRange(newAssignments);
                await _assignmentRepo.SetAsync("assignments", oldAssignments, TimeSpan.FromMinutes(30));

                return Created("", new { message = "Assignment Created", assignments = oldAssignments });
            }
            catch
            {
                return StatusCode(500, new { message = "Assignment process failed" });
            }
        }

        [HttpGet("assignments")]
        public async Task<IActionResult> GetLastAssignment()
        {
            var assignments = await _assignmentRepo.GetAsync<List<AssignmentResult>>("assignments");
            if (assignments == null || !assignments.Any())
                return BadRequest(new { message = "No cached assignments found." });

            return Ok(assignments.Last());
        }
        [HttpDelete("assignments")]
        public async Task<IActionResult> DeleteAssignments()
        {
            var result = await _assignmentRepo.DeleteAsync("assignments");
            if (result)
                return Ok(new { message = "Delete Cache Successful!!" });

            return BadRequest(new { message = "No cached assignments found." });
        }
    }
}

