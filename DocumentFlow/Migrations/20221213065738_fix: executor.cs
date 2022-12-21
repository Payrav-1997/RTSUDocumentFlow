using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class fixexecutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd83f250-71b0-4557-a994-844666b40b89"));

            migrationBuilder.AddColumn<string>(
                name: "Cause",
                table: "Executors",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 13, 6, 57, 38, 396, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Одобрено");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("97c60058-235d-47be-8e49-30acdd2de7c4"), "Test", new DateTime(2022, 12, 13, 6, 57, 38, 479, DateTimeKind.Utc).AddTicks(1523), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$iBi36j3w4PsWxJWlY3UiUOUlIa5bunoGxZ3TaSFjYadjQN4SpZOs.", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97c60058-235d-47be-8e49-30acdd2de7c4"));

            migrationBuilder.DropColumn(
                name: "Cause",
                table: "Executors");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 15, 13, 27, 687, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Одобренно");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("bd83f250-71b0-4557-a994-844666b40b89"), "Test", new DateTime(2022, 12, 12, 15, 13, 27, 769, DateTimeKind.Utc).AddTicks(6105), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$mVMvjfpQDZ73waxXcbJeweRpMKdIqnCODnhefpIPZPngjttdZxzhG", "+992915224442", 1 });
        }
    }
}
