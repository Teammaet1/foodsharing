using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSharing.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9fd491c7-08aa-46d2-81ae-3e9061493aeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9a188547-8348-4e06-9a84-98888504d334");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                column: "ConcurrencyStamp",
                value: "ef374aab-f534-4531-b21f-edd71255614e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62473e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1523590-53c0-4574-baef-180fb375c9b9", "AQAAAAEAACcQAAAAENaH3zP01OlKAvoGMgWSyow164uPCAmyuHNrLUZpJftuZ1EgWbbbDaBtOYBsi0E+xQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d173eac-8562-4aa5-9d69-a91e23905927",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b709752d-0943-411a-9ea9-0b2261625276", "AQAAAAEAACcQAAAAEIPIkwnSNzaKt3osOj1yostXhhhQv7ZCB3iEj+7+c72pMTuv7bFieFMMSfbL4gs0XA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_ApplicationUserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "7a7ec15e-bca9-486f-9605-992e692eba48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "32a9fe38-560d-4f2c-b6ab-ad945b650b54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                column: "ConcurrencyStamp",
                value: "4a0ff656-3282-4eb3-bc17-7c94d47a9f93");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62473e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e0cd0d2-6592-412f-a2af-6e396a1dc407", "AQAAAAEAACcQAAAAELlgJlCANX4k6yZhq7VjtlLLglhUc2Wl2FBNX/0pLyoY1F0S9KWGqUVpiX+9s03cag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d173eac-8562-4aa5-9d69-a91e23905927",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e2154e4-693a-433c-92cc-51139305ad2c", "AQAAAAEAACcQAAAAEGJWO6YVc76eo2QBtyQUEkU6u/uIGIMFiE0ldBW0qN8fp/K635ss/eTFAQnBlYym0w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
