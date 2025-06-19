using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNet_Test_TTSS.Models
{

    public class AssignmentData
    {
        [JsonPropertyName("areaId")]
        public string AreaId { get; set; } = string.Empty;
        [JsonPropertyName("truckId")]
        public string TruckId { get; set; } = string.Empty;
        [JsonPropertyName("availableResources")]
        public Dictionary<string, int> AvailableResources { get; set; } = new();
        [JsonPropertyName("travelTimeToArea")]
        public Dictionary<string, int> TravelTimeToArea { get; set; } = new();
        [JsonPropertyName("timeConstraintHours")]
        public int TimeConstraintHours { get; set; }
    }

    public class AssignmentRequest
    {
        public string AreaId { get; set; } = string.Empty;
        public Dictionary<string, int> ResourcesDelivered { get; set; } = new();
    }

    public class AssignmentResult
    {
        public string AreaId { get; set; } = string.Empty;
        public string TruckId { get; set; } = string.Empty;
        public Dictionary<string, int> ResourcesDelivered { get; set; } = new();
    }


}