using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Test_TTSS.DTOs;
using DotNet_Test_TTSS.Models;

namespace DotNet_Test_TTSS.Mappers
{
    public static class AssignmentMapper
    {
        public static AssignmentRequest ToAssignmentRequest(this AssignmentRequestDto dto)
        {
            return new AssignmentRequest
            {
                AreaId = dto.AreaId,
                ResourcesDelivered = new Dictionary<string, int>(dto.ResourcesDelivered)
            };
        }

        public static AssignmentRequestDto ToAssignmentRequestDto(this AssignmentRequest domain)
        {
            return new AssignmentRequestDto
            {
                AreaId = domain.AreaId,
                ResourcesDelivered = new Dictionary<string, int>(domain.ResourcesDelivered)
            };
        }


        public static AssignmentResultDto ToAssignmentResultDto(AssignmentResult result)
        {
            return new AssignmentResultDto
            {
                AreaId = result.AreaId,
                TruckId = result.TruckId,
                ResourcesDelivered = new Dictionary<string, int>(result.ResourcesDelivered)
            };
        }

        public static AssignmentResult ToAssignmentResult(AssignmentResultDto dto)
        {
            return new AssignmentResult
            {
                AreaId = dto.AreaId,
                TruckId = dto.TruckId,
                ResourcesDelivered = new Dictionary<string, int>(dto.ResourcesDelivered)
            };
        }
    }
}