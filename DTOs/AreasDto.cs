using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Test_TTSS.DTOs
{
    public class AreasDto
    {
        [Required]
        public string AreaId { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int UrgencyLevel { get; set; }

        [Required]
        public Dictionary<string, int> RequiredResources { get; set; } = new();

        [Required]
        public int TimeConstraintHours { get; set; }
    }
}