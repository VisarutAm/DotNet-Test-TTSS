using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Test_TTSS.Models
{
    [Table("areas_new")]
    public class Area 
    {
       
        [Column("area_id")]
        public string AreaId { get; set; }

        [Column("urgency_level")]
        public int UrgencyLevel { get; set; }

        [Column("required_resources")]
        public Dictionary<string, int> RequiredResources { get; set; } = new();

        [Column("time_constraint")]
        public int TimeConstraintHours { get; set; }
    }
}
