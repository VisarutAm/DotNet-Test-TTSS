using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Test_TTSS.DTOs
{
    public class TrucksDto
    {
        [Required]
        public string TruckId { get; set; }
        
        [Required]
        public Dictionary<string, int> AvailableResources { get; set; } = new();

        [Required]
        public Dictionary<string, int> TravelTimeToArea { get; set; } = new();
    }
}