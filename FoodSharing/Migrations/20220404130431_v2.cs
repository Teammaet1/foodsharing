using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSharing.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_ChainShops_ChainShopId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_ChainShopId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "ChainShopId",
                table: "Shops");

            migrationBuilder.AddColumn<Guid>(
                name: "ChainId",
                table: "Shops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ChainId",
                table: "Shops",
                column: "ChainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_ChainShops_ChainId",
                table: "Shops",
                column: "ChainId",
                principalTable: "ChainShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_ChainShops_ChainId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_ChainId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "ChainId",
                table: "Shops");

            migrationBuilder.AddColumn<Guid>(
                name: "ChainShopId",
                table: "Shops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "a7713715-4d67-4940-9871-79b304e99747");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "12b45e2b-149d-47aa-a1ed-7ad62a69dd0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                column: "ConcurrencyStamp",
                value: "a9fde6d9-db6b-4f67-ae3a-313137d524e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62473e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8836ab80-5b71-45a9-801b-d73123390641", "AQAAAAEAACcQAAAAEDrlsLWQaJ8dRWxofOfS5jWWydXSwHMmgujEX8805HOCwWOLkCm9UsPggw/UBmJRQg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d173eac-8562-4aa5-9d69-a91e23905927",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8edf7b8-9d9e-4632-9d11-4417892c960d", "AQAAAAEAACcQAAAAEKU7OYqFcQRdQb5GeHA7IRcvkm3GcRHxcd0MMj8EZwWgr72+AZH0NSy6iYUtFpithQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ChainShopId",
                table: "Shops",
                column: "ChainShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_ChainShops_ChainShopId",
                table: "Shops",
                column: "ChainShopId",
                principalTable: "ChainShops",
                principalColumn: "Id");
        }
    }
}
