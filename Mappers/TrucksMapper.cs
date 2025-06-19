using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Test_TTSS.DTOs;
using DotNet_Test_TTSS.Models;

namespace DotNet_Test_TTSS.Mappers
{
    public static class TrucksMapper
    {
         // แปลง Model เป็น DTO
        public static TrucksDto ToTrucksDto(this Truck truck)
        {
            return new TrucksDto
            {
                TruckId = truck.TruckId,
                AvailableResources = truck.AvailableResources,
                TravelTimeToArea = truck.TravelTimeToArea               
            };
        }

        // แปลง DTO เป็น Model (สำหรับเพิ่มข้อมูลใหม่)
        public static Truck ToTruck(this TrucksDto dto)
        {
            return new Truck
            {
                TruckId = dto.TruckId,
                AvailableResources = dto.AvailableResources,
                TravelTimeToArea = dto.TravelTimeToArea                
            };
        }
    }
}