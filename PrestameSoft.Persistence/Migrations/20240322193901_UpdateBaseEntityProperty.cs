using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestameSoft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseEntityProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Payments",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Loans",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Clients",
                newName: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Payments",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Loans",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Clients",
                newName: "State");
        }
    }
}
