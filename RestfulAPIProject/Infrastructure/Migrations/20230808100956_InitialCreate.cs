using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestfulAPIProject.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Password", "Status", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 8, 13, 9, 56, 798, DateTimeKind.Local).AddTicks(5309), null, "123456", 1, null, "test1" },
                    { 2, new DateTime(2023, 8, 8, 13, 9, 56, 798, DateTimeKind.Local).AddTicks(5310), null, "123456", 1, null, "test2" },
                    { 3, new DateTime(2023, 8, 8, 13, 9, 56, 798, DateTimeKind.Local).AddTicks(5312), null, "123456", 1, null, "test3" },
                    { 4, new DateTime(2023, 8, 8, 13, 9, 56, 798, DateTimeKind.Local).AddTicks(5313), null, "123456", 1, null, "test4" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 8, 13, 9, 56, 798, DateTimeKind.Local).AddTicks(5133), null, "Et ve Tavuk Ürünleri Bulunur!", "Kasap", 1, null },
                    { 2, new DateTime(2023, 8, 8, 13, 9, 56, 798, DateTimeKind.Local).AddTicks(5143), null, "Meyve ve Sebzeler Bulunur!", "Manav", 1, null },
                    { 3, new DateTime(2023, 8, 8, 13, 9, 56, 798, DateTimeKind.Local).AddTicks(5145), null, "Süt Ürünleri Bulunur!", "Şarküteri", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
