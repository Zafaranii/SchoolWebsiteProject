using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day_10.Migrations
{
    /// <inheritdoc />
    public partial class da : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "degree",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "degree",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
