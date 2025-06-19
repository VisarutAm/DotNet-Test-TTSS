using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_Test_TTSS.Models
{
        [Table("trucks_new")]
        public class Truck
        {

            [Column("truck_id")]
            public string TruckId { get; set; }

            [Column("available_resources")]
            public Dictionary<string, int> AvailableResources { get; set; } = new();

            [Column("travel_time_toarea")]
            public Dictionary<string, int> TravelTimeToArea { get; set; } = new();


        }
    
}