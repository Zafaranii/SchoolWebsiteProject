using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day_10.Migrations
{
    /// <inheritdoc />
    public partial class dayfi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Students",
                type: "nvarchar(23)",
                maxLength: 23,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Instructors",
                type: "nvarchar(23)",
                maxLength: 23,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(23)",
                oldMaxLength: 23);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(23)",
                oldMaxLength: 23);
        }
    }
}
