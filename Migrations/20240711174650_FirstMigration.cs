using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athletes.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PointsPerGame = table.Column<decimal>(type: "decimal(16,1)", precision: 16, scale: 1, nullable: false),
                    ReboundsPerGame = table.Column<decimal>(type: "decimal(16,1)", precision: 16, scale: 1, nullable: false),
                    AssistsPerGame = table.Column<decimal>(type: "decimal(16,1)", precision: 16, scale: 1, nullable: false),
                    FieldGoalPercentage = table.Column<decimal>(type: "decimal(16,1)", precision: 16, scale: 1, nullable: false),
                    ThreePointPercentage = table.Column<decimal>(type: "decimal(16,1)", precision: 16, scale: 1, nullable: false),
                    Championships = table.Column<int>(type: "int", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athletes");
        }
    }
}
