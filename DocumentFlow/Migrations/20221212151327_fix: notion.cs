using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class fixnotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61ba371d-3228-410b-bb99-ed9430a6ab42"));

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId",
                table: "Notions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 15, 13, 27, 687, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("bd83f250-71b0-4557-a994-844666b40b89"), "Test", new DateTime(2022, 12, 12, 15, 13, 27, 769, DateTimeKind.Utc).AddTicks(6105), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$mVMvjfpQDZ73waxXcbJeweRpMKdIqnCODnhefpIPZPngjttdZxzhG", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd83f250-71b0-4557-a994-844666b40b89"));

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Notions");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 15, 0, 56, 277, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("61ba371d-3228-410b-bb99-ed9430a6ab42"), "Test", new DateTime(2022, 12, 12, 15, 0, 56, 358, DateTimeKind.Utc).AddTicks(8295), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$ZrT8SU/Hrp2FtE7XlpeDG.jVSyj2VTGSroLLwHHM3HdO0fbck1GJC", "+992915224442", 1 });
        }
    }
}
