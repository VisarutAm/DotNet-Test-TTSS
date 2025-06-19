using DotNet_Test_TTSS.Models;
using DotNet_Test_TTSS.DTOs;

namespace DotNet_Test_TTSS.Mappers
{
    public static class AreaMapper
    {
        // แปลง Model เป็น DTO
        public static AreasDto ToAreaDto(this Area area)
        {
            return new AreasDto
            {
                AreaId = area.AreaId,
                UrgencyLevel = area.UrgencyLevel,
                RequiredResources = area.RequiredResources,
                TimeConstraintHours = area.TimeConstraintHours
            };
        }

        // แปลง DTO เป็น Model (สำหรับเพิ่มข้อมูลใหม่)
        public static Area ToArea(this AreasDto dto)
        {
            return new Area
            {
                AreaId = dto.AreaId,
                UrgencyLevel = dto.UrgencyLevel,
                RequiredResources = dto.RequiredResources,
                TimeConstraintHours = dto.TimeConstraintHours
            };
        }

        // ถ้าต้องการแยกแบบ Update ก็สร้างเมธอดเพิ่มได้ เช่น
        // public static void UpdateAreaFromDto(this Area area, AreasDto dto)
        // {
        //     area.UrgencyLevel = dto.UrgencyLevel;
        //     area.RequiredResources = dto.RequiredResources;
        //     area.TimeConstraintHours = dto.TimeConstraintHours;
        //     // AreaId อาจไม่แก้ไข เพราะเป็น PK
        // }
    }
}