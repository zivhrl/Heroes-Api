using Microsoft.EntityFrameworkCore.Migrations;

namespace Heroes_Api.Migrations
{
    public partial class AddedDateToStartedTrainingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "StartedTraining",
                table: "Heroes",
                newName: "StartedTrainingDate");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "14c46e43-e5a9-4cb4-a803-b4a02de8f180", 0, "ecafdfc4-c918-45c4-a50d-4828d354c1a4", "ziv@t.com", false, false, null, "ZIV@T.COM", "ZIV", "AQAAAAEAACcQAAAAEPLWN1BgeR+18FTMMFd1qpV0lNG+76IKpoGvh3kvv6TPh+4ji3myvxudCIs2mjzB+A==", null, false, "a8883e3e-b59c-4125-956a-213d06c515d9", false, "ziv" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ad0a8cf-5c4d-4638-89b1-4c2b61c41b28", 0, "d89ee644-f187-4871-b79b-ad841d715843", "rony@t.com", false, false, null, "RONY@T.COM", "RONY", "AQAAAAEAACcQAAAAEP6xEfCw0/1SLgkPRtYEurqUYu9pjP4UbEh3aByW8MojpT2F30jdxwZGKKADeJ6iwg==", null, false, "5de72680-6b11-4cf0-8237-9c4c9612ed5b", false, "rony" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d905984-22e8-4c30-bd92-13d744d805f9", 0, "09dab628-9874-4f48-a500-6104bd26324d", "dani@t.com", false, false, null, "DANI@T.COM", "DANI", "AQAAAAEAACcQAAAAEDen0zdJTTu3V8Cldeeo54nnD6oNtSQLd90eBuOe61q5LE3Rm7Tv/kn3QUHngiJnvA==", null, false, "b2731828-ef21-41ae-b455-56a4ee7da50d", false, "dani" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14c46e43-e5a9-4cb4-a803-b4a02de8f180");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d905984-22e8-4c30-bd92-13d744d805f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ad0a8cf-5c4d-4638-89b1-4c2b61c41b28");

            migrationBuilder.RenameColumn(
                name: "StartedTrainingDate",
                table: "Heroes",
                newName: "StartedTraining");

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
    }
}
