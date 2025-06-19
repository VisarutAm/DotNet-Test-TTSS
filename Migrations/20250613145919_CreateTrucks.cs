using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet_Test_TTSS.Migrations
{
    /// <inheritdoc />
    public partial class CreateTrucks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trucks1",
                columns: table => new
                {
                    truck_id = table.Column<string>(type: "text", nullable: false),
                    available_resources = table.Column<Dictionary<string, int>>(type: "jsonb", nullable: false),
                    travel_time_toarea = table.Column<Dictionary<string, int>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucks1", x => x.truck_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trucks1");
        }
    }
}
