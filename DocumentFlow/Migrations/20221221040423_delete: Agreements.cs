using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentFlow.Migrations
{
    /// <inheritdoc />
    public partial class deleteAgreements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e569ae4-5787-4ece-b4c8-011662305d25"));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 12, 21, 4, 4, 23, 306, DateTimeKind.Utc).AddTicks(8923), "Алиф" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("3bd73b24-666f-41f7-bb5c-3dc6950c56d4"), "Test", new DateTime(2022, 12, 21, 4, 4, 23, 389, DateTimeKind.Utc).AddTicks(1769), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$sOH9IQCNz9MZVfb2kRb0g.vm3Z1ZoPB7qI/dqsAGyB4QKJ11EJiLu", "+992915224442", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3bd73b24-666f-41f7-bb5c-3dc6950c56d4"));

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgreementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descrioption = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreements_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agreements_Executors_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Executors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 12, 21, 3, 25, 32, 874, DateTimeKind.Utc).AddTicks(3319), "Test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DepartmentId", "Email", "Logo", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { new Guid("9e569ae4-5787-4ece-b4c8-011662305d25"), "Test", new DateTime(2022, 12, 21, 3, 25, 32, 955, DateTimeKind.Utc).AddTicks(3568), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Admin@gmail.com", "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg", "Админ", "$2b$10$FzoOqyj6i03wNAInyAI3b.ScsuhcgXJlckpmohi2xvpsNEmwHZVye", "+992915224442", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_DocumentId",
                table: "Agreements",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_ExecutorId",
                table: "Agreements",
                column: "ExecutorId");
        }
    }
}
