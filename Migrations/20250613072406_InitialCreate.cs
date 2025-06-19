using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet_Test_TTSS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areas1",
                columns: table => new
                {
                    area_id = table.Column<string>(type: "text", nullable: false),
                    urgency_level = table.Column<int>(type: "integer", nullable: false),
                    required_resources = table.Column<Dictionary<string, int>>(type: "jsonb", nullable: false),
                    time_constraint = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas1", x => x.area_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areas1");
        }
    }
}
