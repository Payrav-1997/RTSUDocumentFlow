using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class featNotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b5155727-86b9-4937-a351-77a1ed0d9b55"));

            migrationBuilder.CreateTable(
                name: "Notions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 12, 15, 58, 822, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("f7489d2a-5e75-4fda-a8cf-554e6bded6be"), "Test", new DateTime(2022, 12, 12, 12, 15, 58, 900, DateTimeKind.Utc).AddTicks(1590), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$LxHjPhSN/RM8Bi8CVhKMF.EH/GxoZzaIV35ZL3d27yxMcUIo/qVPi", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f7489d2a-5e75-4fda-a8cf-554e6bded6be"));

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
    }
}
