using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlBulkCopyTest.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTable");

            migrationBuilder.CreateTable(
                name: "TestTableEfs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Field1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field10 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTableEfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Field1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field10 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTables", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTableEfs");

            migrationBuilder.DropTable(
                name: "TestTables");

            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Field1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field9 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.Id);
                });
        }
    }
}
