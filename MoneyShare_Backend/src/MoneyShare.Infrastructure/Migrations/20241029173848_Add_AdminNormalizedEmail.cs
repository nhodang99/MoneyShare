using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_AdminNormalizedEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aa6e184-4632-4c58-bee0-bc8876b16546");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fef49777-5d92-4117-83f5-ac7a4d14f957", "a1eed11e-38d2-42b6-be5f-88689f574137" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fef49777-5d92-4117-83f5-ac7a4d14f957");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1eed11e-38d2-42b6-be5f-88689f574137");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2208f063-85b6-44d1-a5fe-56af87ea2ca6", null, "User", "USER" },
                    { "88f45721-5c4f-41a7-a6b0-166d26471f0f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "787d7c24-4453-46fe-b270-ddbe27ad6c36", 0, "d925c1c1-5afc-4cf0-8618-2948b125a9e0", "admin@moneyshare.com", false, false, null, "ADMIN@MONEYSHARE.COM", "ADMIN", "AQAAAAIAAYagAAAAECe9mA8B3tQUC0tTNz47cT5cvQ2SNuMYkNxRkWp51RqXIosc1u0qKotBB3MuSdbrAg==", null, false, null, null, "ca851597-6860-46d3-b8ef-b137c15728d3", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "88f45721-5c4f-41a7-a6b0-166d26471f0f", "787d7c24-4453-46fe-b270-ddbe27ad6c36" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2208f063-85b6-44d1-a5fe-56af87ea2ca6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88f45721-5c4f-41a7-a6b0-166d26471f0f", "787d7c24-4453-46fe-b270-ddbe27ad6c36" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88f45721-5c4f-41a7-a6b0-166d26471f0f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "787d7c24-4453-46fe-b270-ddbe27ad6c36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1aa6e184-4632-4c58-bee0-bc8876b16546", null, "User", "USER" },
                    { "fef49777-5d92-4117-83f5-ac7a4d14f957", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1eed11e-38d2-42b6-be5f-88689f574137", 0, "c2d4e3f1-b73e-44ee-b0e2-1f4e3171913d", "admin@moneyshare.com", false, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEL9tGvwGiFnJvhbjTFN1Q5R/ZKKGlP1/7njqNXwLgqJC1gruD6rC9wRt52CxV8o10g==", null, false, null, null, "0e44cf5b-69a8-4522-b0ec-9154f489c9a1", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fef49777-5d92-4117-83f5-ac7a4d14f957", "a1eed11e-38d2-42b6-be5f-88689f574137" });
        }
    }
}
