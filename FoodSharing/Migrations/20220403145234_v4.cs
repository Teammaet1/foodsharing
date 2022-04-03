using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSharing.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e05-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9a0e304c-b82d-4708-bd16-2ec6928d3a0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "55886884-c11f-424a-beaa-3c3417373d0a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0a2c66f-5df2-4b4f-b493-8fa324f1897a", "AQAAAAEAACcQAAAAEIyltSaVYNe8Z+00PkWXx+af9NEcV4OES9C66lQQIyKKT+lCCQgAVj/SaGpNqsDSlw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondId",
                table: "Orders");

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
        }
    }
}
