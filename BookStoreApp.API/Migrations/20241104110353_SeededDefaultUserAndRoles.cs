using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5fe66c6-746e-47fc-9e6b-99c0fd9d29ec", null, "User", "USER" },
                    { "fd67e261-fd62-4be2-9328-04bbbbf4315c", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "53ea03e5-6201-4544-964f-3e7e3e93e2b2", 0, "664735af-58f3-4ba7-8996-ba9ba34abb9b", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEEZ5/KN2BsOCDXWajbw3r59uFi7grdbW9BtrQ+YMvmtM97lqLEyoF78pNzfRmYwU0g==", null, false, "88546b28-12ea-4571-acf9-7d54eee0e276", false, "user@bookstore.com" },
                    { "a5c661b7-7774-4af5-8327-28259dc9b53c", 0, "93243aeb-0f3f-4a33-924d-dd55f733ff9f", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEIfRfRzEYOZytihI/z0nKKogF7kH4Tc4PzGo6wzglvkinnVDvNCKAAzAeQIpkTGsgw==", null, false, "5b2de7e1-b5ce-4f58-b74a-06285893142d", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a5fe66c6-746e-47fc-9e6b-99c0fd9d29ec", "53ea03e5-6201-4544-964f-3e7e3e93e2b2" },
                    { "fd67e261-fd62-4be2-9328-04bbbbf4315c", "a5c661b7-7774-4af5-8327-28259dc9b53c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5fe66c6-746e-47fc-9e6b-99c0fd9d29ec", "53ea03e5-6201-4544-964f-3e7e3e93e2b2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd67e261-fd62-4be2-9328-04bbbbf4315c", "a5c661b7-7774-4af5-8327-28259dc9b53c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5fe66c6-746e-47fc-9e6b-99c0fd9d29ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd67e261-fd62-4be2-9328-04bbbbf4315c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53ea03e5-6201-4544-964f-3e7e3e93e2b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5c661b7-7774-4af5-8327-28259dc9b53c");
        }
    }
}
