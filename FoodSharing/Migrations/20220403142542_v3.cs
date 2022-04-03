using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSharing.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "shopId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e05-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9f1fa843-2d70-4d49-95c6-2d2f0e23fd5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "4f44d7b0-497e-4e9f-8cb4-845d83fe928a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e416a45d-5722-4f52-af8a-4234d0c7c07e", "AQAAAAEAACcQAAAAEFoxFlh35+lDx7oB7fCEDdD/jIg0KJ0jfmYZAsQfOmPs2w7D5cjWyoQQYe3qzu1BSw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_shopId",
                table: "Orders",
                column: "shopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shops_shopId",
                table: "Orders",
                column: "shopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shops_shopId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_shopId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "shopId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e05-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "784cad2e-82c1-4dbc-97c8-9f884627114d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "bdbd35cc-0f92-4945-bad5-7aa4c1dd6993");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b0b02a5-e4ba-40fa-8df7-6c38e8daebd1", "AQAAAAEAACcQAAAAEN9QUamQ9lyGFANeSwAMf4xQ0A66LH3Zcu0BJvl/iWwtODcXqK/LyCizfw0J8cSANQ==" });
        }
    }
}
