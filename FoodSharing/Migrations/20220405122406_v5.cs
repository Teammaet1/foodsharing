using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSharing.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.CreateTable(
                name: "CountProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CountProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "bf39ba1c-5312-48ba-abc3-d30c8bfadacd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "290a098d-de6d-4128-b7a2-683c4ed6e438");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                column: "ConcurrencyStamp",
                value: "11b95700-042a-42bc-9b92-5f4c691996f8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62473e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b5a6e21-c8ab-4e6f-b8dd-a80a6b685b60", "AQAAAAEAACcQAAAAEGZ5d0pUyMJ1BbKRFdAz/OWqXhHTkMSuMlIPVbholLg8RUz8MwCnuEI41D+90RseKw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d173eac-8562-4aa5-9d69-a91e23905927",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71df0af0-d169-40b7-baa3-fd6b72b3519b", "AQAAAAEAACcQAAAAEKFLU4NzDHVdZOn29fvU85TGbVfZEuXPZq+aToWdIISb6deZlOAksZgUpMVh567j3g==" });

            migrationBuilder.CreateIndex(
                name: "IX_CountProducts_OrderId",
                table: "CountProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CountProducts_ProductId",
                table: "CountProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountProducts");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");
        }
    }
}
