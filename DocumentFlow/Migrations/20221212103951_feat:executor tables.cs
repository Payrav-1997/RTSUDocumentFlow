using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class featexecutortables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cbf47816-2c5d-4a01-9d05-6e975ad8e71d"));

            migrationBuilder.AlterColumn<string>(
                name: "ExecutionTime",
                table: "Executors",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfOrder",
                table: "Executors",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 10, 39, 51, 678, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Исполниель" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("21c71587-bf83-44ce-a952-d86c1016e516"), "Test", new DateTime(2022, 12, 12, 10, 39, 51, 762, DateTimeKind.Utc).AddTicks(7955), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$X7L4I5U8FuTPHC3PrSC3uOIzQP0OzcTWcjv3J6lUXHnc3GIfLYVWy", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("21c71587-bf83-44ce-a952-d86c1016e516"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExecutionTime",
                table: "Executors",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfOrder",
                table: "Executors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 8, 14, 14, 36, 920, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("cbf47816-2c5d-4a01-9d05-6e975ad8e71d"), "Test", new DateTime(2022, 12, 8, 14, 14, 37, 7, DateTimeKind.Utc).AddTicks(3039), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$G6Ni0U9z.W9vFwxwuvcwUOHFMn4E5y7eer.rBTE66cVmmMESZrLbS", "+992915224442", 1 });
        }
    }
}
