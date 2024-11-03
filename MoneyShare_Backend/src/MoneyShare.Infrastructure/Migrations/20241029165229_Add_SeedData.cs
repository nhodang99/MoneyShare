using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c24216b5-8bb9-4d68-92ec-2b77f212baa1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc751564-a924-406e-aa5e-6bd3d46856a5");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c24216b5-8bb9-4d68-92ec-2b77f212baa1", null, "User", "USER" },
                    { "fc751564-a924-406e-aa5e-6bd3d46856a5", null, "Admin", "ADMIN" }
                });
        }
    }
}
