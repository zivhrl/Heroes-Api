using Microsoft.EntityFrameworkCore.Migrations;

namespace Heroes_Api.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d3f2fff-15e5-478b-9d4a-ea0af664b170", 0, "563b2220-c569-4977-b049-a7fffaa32096", "ziv@t.com", false, false, null, "ZIV@T.COM", "ZIV", "AQAAAAEAACcQAAAAEPPj4dtJ2L4Im9qdmm/mxVVFBkexelDOXny1OJn5uKRDDkZSIT1j/5egLP3fBeGv3Q==", null, false, "659d7e23-c251-479c-9cec-4bb4608ceb43", false, "ziv" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9a3eef16-f4ee-4928-8341-c1b1398ee2c9", 0, "f6a78b96-caee-416c-9b39-761b6e7c952e", "rony@t.com", false, false, null, "RONY@T.COM", "RONY", "AQAAAAEAACcQAAAAEGZwINuvjKPS8g5YG4+EZg44uDKMDtwAU5aGLewKZ/2sVoYUs5flLdxe55KpI60paw==", null, false, "80b43b6a-3264-4be8-8dee-25ccd90a492b", false, "rony" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "56a922b4-d9a8-4cb4-ba10-718dd2e8b5f1", 0, "0978de4f-7cf0-4255-adcd-49cfcb940d20", "dani@t.com", false, false, null, "DANI@T.COM", "DANI", "AQAAAAEAACcQAAAAENDXV+lz7z8GOR3kgdQ218aRMtYOT43vr9/tryP//Y26tecVMhM+lSN4meg85e0mJw==", null, false, "fdd120d0-f916-4baf-aeae-af947ca6430c", false, "dani" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56a922b4-d9a8-4cb4-ba10-718dd2e8b5f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d3f2fff-15e5-478b-9d4a-ea0af664b170");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a3eef16-f4ee-4928-8341-c1b1398ee2c9");
        }
    }
}
