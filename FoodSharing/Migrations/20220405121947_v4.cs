using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSharing.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "1cbc2acf-91e3-4b5f-a7fe-a3a7c21d6b62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "efc32923-e10c-42c1-850d-b02cf32a561e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                column: "ConcurrencyStamp",
                value: "f9ea6991-c847-44b6-be88-affa50acfad6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62473e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3badb09a-7eaa-4767-b1db-601870670c2f", "AQAAAAEAACcQAAAAEL/euvuJyCAPxqwyLcFQqOKIhnJ7G8Ligj5nMeHgPdKQm4FN8O/h+dgFVLCbIDhDbA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d173eac-8562-4aa5-9d69-a91e23905927",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "876f11ad-aec4-405c-8f36-e02e9af70d13", "AQAAAAEAACcQAAAAEIK1pUK6h/qk3vz5Q+gPM+NYD00dV9t2sI7aMdIG6eKRDOYvwF0ZbBnoghQ5BbHkNw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "4a544992-4973-4ad0-b571-300031eef8a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "6a83eed3-1c5c-4581-849a-460bc0ab8061");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                column: "ConcurrencyStamp",
                value: "f5a33b55-2b39-4676-b414-23a6d1a0f7ed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62473e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67b99df9-bc3b-4b5c-b1f5-cc5a66ec1358", "AQAAAAEAACcQAAAAEGVap4m5++xPzY2xNT4w76PRCG9ZgNUoKtkNAyB+OKlhGTAfq5fKpammVwEfZPX72Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d173eac-8562-4aa5-9d69-a91e23905927",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8842e94-93ef-441a-8a5a-91088997ef39", "AQAAAAEAACcQAAAAEPLp+A/AyB61y6voYbYaYR1e75UzipOJcnnXXnjwgaPhBre8WH2CIfCNK4HqXmNXvg==" });
        }
    }
}
