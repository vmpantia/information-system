using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IS.Web.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Manager_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.InternalID);
                });

            migrationBuilder.CreateTable(
                name: "Department_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    InternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_InternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_TRN", x => x.RequestID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Department_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.InternalID);
                });

            migrationBuilder.CreateTable(
                name: "Position_TRN",
                columns: table => new
                {
                    RequestId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    InternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_InternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position_TRN", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FunctionID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Department_TRN");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Position_TRN");

            migrationBuilder.DropTable(
                name: "Request");
        }
    }
}
