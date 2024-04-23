using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestameSoft.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserNameIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0899b4-961c-4a67-90e8-53aedac5c370",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8d8112d2-0683-4dbd-9930-6b9eb5a0facb", "AQAAAAIAAYagAAAAEN0Mazy8l3e3foWhV1AzQmDO7Qny/lQrWwBH1RwcZTleU9AbLlrvP+ec9pR/s4zMQw==", "dd603420-3908-4b46-bd82-48205eadeed6", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cb7dbdd-ebbd-4501-9c2e-67e5cffc3d73",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "13faa1c8-1a00-49d3-9112-6ddbb214a45f", "AQAAAAIAAYagAAAAELQwFix1ObWJCceCS0PUm1+1OpzB0f+Yi9YopuUA+0776l8Ocjv7sBUGkSM/8SPc4A==", "49a2c521-1416-42d1-bcd1-4521b8386c4e", "user@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0899b4-961c-4a67-90e8-53aedac5c370",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6541d38a-0f81-42ea-9857-00345b0e5b3e", "AQAAAAIAAYagAAAAEHZZyJKH45H1MMzpfQHxC4Qgs1wXr/QW4xxHB4RiuIyuAmBhtbwI2Sog6vA89KbKDA==", "bc67507e-f0b0-48a5-98e4-64e5abbd186c", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cb7dbdd-ebbd-4501-9c2e-67e5cffc3d73",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "173dcd3e-8ff0-4d08-83f9-bbf472b4df18", "AQAAAAIAAYagAAAAEFtIhw091PkvGKkExmnFCqhWz0OzXnjBjICFm0Eu6lG0zeBi5aSrnff8sP1QGF01Xw==", "5ed35793-a564-4627-8122-f33350c77bbe", null });
        }
    }
}
