using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class fixuserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("21c71587-bf83-44ce-a952-d86c1016e516"));

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Executors");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 11, 41, 18, 225, DateTimeKind.Utc).AddTicks(2749));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("b5155727-86b9-4937-a351-77a1ed0d9b55"), "Test", new DateTime(2022, 12, 12, 11, 41, 18, 308, DateTimeKind.Utc).AddTicks(5333), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$b.QMPeefK8RR4oLYG5TT0e8yU23rrZTQTsOb8xlcxeCVjf66nrpWi", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b5155727-86b9-4937-a351-77a1ed0d9b55"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Executors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 10, 39, 51, 678, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("21c71587-bf83-44ce-a952-d86c1016e516"), "Test", new DateTime(2022, 12, 12, 10, 39, 51, 762, DateTimeKind.Utc).AddTicks(7955), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$X7L4I5U8FuTPHC3PrSC3uOIzQP0OzcTWcjv3J6lUXHnc3GIfLYVWy", "+992915224442", 1 });
        }
    }
}
