using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athletes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ThreePointPercentage",
                table: "Athletes",
                type: "decimal(16,1)",
                precision: 16,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReboundsPerGame",
                table: "Athletes",
                type: "decimal(16,1)",
                precision: 16,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "PointsPerGame",
                table: "Athletes",
                type: "decimal(16,1)",
                precision: 16,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "FieldGoalPercentage",
                table: "Athletes",
                type: "decimal(16,1)",
                precision: 16,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "AssistsPerGame",
                table: "Athletes",
                type: "decimal(16,1)",
                precision: 16,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ThreePointPercentage",
                table: "Athletes",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,1)",
                oldPrecision: 16,
                oldScale: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReboundsPerGame",
                table: "Athletes",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,1)",
                oldPrecision: 16,
                oldScale: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "PointsPerGame",
                table: "Athletes",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,1)",
                oldPrecision: 16,
                oldScale: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "FieldGoalPercentage",
                table: "Athletes",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,1)",
                oldPrecision: 16,
                oldScale: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "AssistsPerGame",
                table: "Athletes",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,1)",
                oldPrecision: 16,
                oldScale: 1);
        }
    }
}
