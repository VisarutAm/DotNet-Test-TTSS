using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Test_TTSS.DTOs
{
    public class AssignmentDataDto
    {
        public string AreaId { get; set; } = string.Empty;
        public string TruckId { get; set; } = string.Empty;
        public Dictionary<string, int> AvailableResources { get; set; } = new();
        public Dictionary<string, int> TravelTimeToArea { get; set; } = new();
        public int TimeConstraintHours { get; set; }
    }

        public class AssignmentRequestDto
    {
        public string AreaId { get; set; } = string.Empty;
        public Dictionary<string, int> ResourcesDelivered { get; set; } = new();
    }

    public class AssignmentResultDto
    {
        public string AreaId { get; set; } = string.Empty;
        public string TruckId { get; set; } = string.Empty;
        public Dictionary<string, int> ResourcesDelivered { get; set; } = new();
    }



}