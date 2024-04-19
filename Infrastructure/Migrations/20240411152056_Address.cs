using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Addresses",
                newName: "AddressLine_1");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine_2",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine_2",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "AddressLine_1",
                table: "Addresses",
                newName: "StreetName");
        }
    }
}
