using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class featstatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f7489d2a-5e75-4fda-a8cf-554e6bded6be"));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 15, 0, 56, 277, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Сотрудник");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "В процессе");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Отказано" },
                    { 4, "Одобренно" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("61ba371d-3228-410b-bb99-ed9430a6ab42"), "Test", new DateTime(2022, 12, 12, 15, 0, 56, 358, DateTimeKind.Utc).AddTicks(8295), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$ZrT8SU/Hrp2FtE7XlpeDG.jVSyj2VTGSroLLwHHM3HdO0fbck1GJC", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61ba371d-3228-410b-bb99-ed9430a6ab42"));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 12, 15, 58, 822, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Пользователь");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Одобренно");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("f7489d2a-5e75-4fda-a8cf-554e6bded6be"), "Test", new DateTime(2022, 12, 12, 12, 15, 58, 900, DateTimeKind.Utc).AddTicks(1590), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$LxHjPhSN/RM8Bi8CVhKMF.EH/GxoZzaIV35ZL3d27yxMcUIo/qVPi", "+992915224442", 1 });
        }
    }
}
