using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class fixUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3bd73b24-666f-41f7-bb5c-3dc6950c56d4"));

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 30, 21, 12, 43, 241, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("8e5f4aa5-838a-4263-922a-c0bb4ba71765"), "Test", new DateTime(2022, 12, 30, 21, 12, 43, 329, DateTimeKind.Utc).AddTicks(256), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$aT0GmmszG8EgTBSm9J7ok.e9UjdyAoKGgDiXgJjPO88.L5bEfKtHa", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8e5f4aa5-838a-4263-922a-c0bb4ba71765"));

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 4, 4, 23, 306, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("3bd73b24-666f-41f7-bb5c-3dc6950c56d4"), "Test", new DateTime(2022, 12, 21, 4, 4, 23, 389, DateTimeKind.Utc).AddTicks(1769), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$sOH9IQCNz9MZVfb2kRb0g.vm3Z1ZoPB7qI/dqsAGyB4QKJ11EJiLu", "+992915224442", 1 });
        }
    }
}
